using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TaskChecker.Core;
using TaskChecker.Web.Database;
using TaskChecker.Web.Models;
using TaskChecker.Web.Models.Entities;

namespace TaskChecker.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var currentStudent = db.Students.Include(x => x.Courses).FirstOrDefault(x => x.User.UserName == User.Identity.Name);

            if (currentStudent == null)
            {
                return Content("you are not a student. ask your teacher add you.");
            }

            return View(currentStudent);
        }

        public ActionResult LabWork(int id)
        {
            var labWork = db.LabWorks.FirstOrDefault(x => x.Id == id);

            if (labWork == null)
            {
                return HttpNotFound();
            }

            return View(labWork);
        }

        public ActionResult Exercise(int id)
        {
            var exercise = db.Exercises.Include(x => x.LabWork).FirstOrDefault(x => x.Id == id);
            var submissions = db.Submissions.Include(x => x.TestResults).Where(x => x.Exercise.Id == id && x.Student.User.UserName == User.Identity.Name);

            if (exercise == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ExerciseViewModel
            {
                Exercise = exercise,
                Submissions = submissions
            };
            return View(viewModel);
        }

        public ActionResult Submission(int id)
        {
            var submission = db.Submissions.Include(x => x.Exercise).Include(x => x.SubmittedContent).FirstOrDefault(x => x.Id == id);

            if (submission == null)
            {
                return HttpNotFound();
            }

            return View(submission);
        }

        [HttpPost]
        public ActionResult Submission(int id, bool isFinal)
        {
            var submission = db.Submissions.FirstOrDefault(x => x.Id == id);

            if (submission == null)
            {
                return HttpNotFound();
            }

            submission.IsFinal = isFinal;
            db.SaveChanges();

            return RedirectToAction("Submission", new {Id = id});
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ExerciseSubmission(int exerciseId, string content, bool isStatic, string typeName, string methodName)
        {
            var exercise = db.Exercises.FirstOrDefault(x => x.Id == exerciseId);

            if (exercise == null)
            {
                return HttpNotFound();
            }

            var submission = SaveSubmission(exercise, content, isStatic, typeName, methodName);
            var taskFunction = GetTaskFunction(content, isStatic, typeName, methodName);
            var testResults = RunTests(exercise, taskFunction);

            submission = UpdateSubmission(submission, testResults);

            return RedirectToAction("Submission", new {Id = submission.Id });
        }

        private Submission SaveSubmission(Exercise exercise, string content, bool isStatic, string typeName, string methodName)
        {
            var currentStudent = db.Students.FirstOrDefault(x => x.User.UserName == User.Identity.Name);
            var submission = new Submission
            {
                Exercise = exercise,
                Created = DateTime.Now,
                Student = currentStudent,
                SubmittedContent = new SubmittedContent
                {
                    Content = content,
                    IsStatic = isStatic,
                    TypeName = typeName,
                    MethodName = methodName
                }
            };

            db.Submissions.Add(submission);
            db.SaveChanges();

            return submission;
        }

        private Submission UpdateSubmission(Submission submission, IList<TestResult> testResults)
        {
            var exerciseResults = new List<ExerciseTestResult>();

            foreach (var testResult in testResults)
            {
                var exerciseResult = new ExerciseTestResult
                {
                    IsPassed = testResult.IsPassed
                };

                if (testResult.IsPassed)
                {
                    exerciseResult.Information = $"Test {testResult.TestName} passed.";
                }
                else
                {
                    var exception = Unwrap(testResult.Exception);
                    exerciseResult.Information = $"Test {testResult.TestName} failed.\nDetails: {exception.Message}";
                }

                exerciseResults.Add(exerciseResult);
            }

            submission.TestResults = exerciseResults;
            submission.IsTested = true;

            db.SaveChanges();

            return submission;
        }

        private static Exception Unwrap(Exception sourceException)
        {
            Exception exception = sourceException;
            while (true)
            {
                if (exception is TargetInvocationException invocationException)
                {
                    exception = invocationException.InnerException;
                }
                else
                {
                    break;
                }
            }
            return exception;
        }

        private TaskFunction GetTaskFunction(string content, bool isStatic, string typeName, string methodName)
        {
            var creator = new AssemblyCreator(content);
            var assembler = creator.CreateAssembly();
            var type = assembler.GetType(typeName);
            if (type == null)
            {
                throw new NotSupportedException();
            }

            var method = type.GetMethod(methodName);
            if (method == null)
            {
                throw new NotSupportedException();
            }

            TaskFunction taskFunction;
            if (isStatic)
            {
                taskFunction = (parameters) => method.Invoke(null, parameters);
            }
            else
            {
                var instance = Activator.CreateInstance(type);
                taskFunction = (parameters) => method.Invoke(instance, parameters);
            }

            
            return taskFunction;
        }

        private IList<TestResult> RunTests(Exercise exercise, TaskFunction taskFunction)
        {
            var assemblyName = "TaskChecker.Tests";
            var testNames = GetTestNames(exercise);
            var testRunner = new TestRunner(assemblyName);

            var result = new List<TestResult>();
            foreach (var testName in testNames)
            {
                result.AddRange(testRunner.Run(testName, taskFunction));
            }
            return result;
        }

        private IEnumerable<string> GetTestNames(Exercise exercise)
        {
            var testNames = exercise.ExerciseTests.Where(x => x.IsEnabled).Select(x => x.TypeName);
            return testNames;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}