using Lab5;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            return View(currentStudent);
        }

        public ActionResult CourseClass(int id)
        {
            var courseClass = db.CourseClasses.Include(x => x.LabWorks).FirstOrDefault(x => x.Id == id);

            if(courseClass == null)
            {
                return HttpNotFound();
            }

            return View(courseClass);
        }

        public ActionResult LabWork(int id)
        {
            var labWork = db.LabWorks.FirstOrDefault(x => x.Id == id);

            if (labWork == null)
            {
                return HttpNotFound();
            }
            var labWorkResult = db.LabWorkResults
                .Include(x => x.ExerciseResults.Select(y => y.Exercise))
                .FirstOrDefault(x => x.LabWork.Id == labWork.Id && x.Student.User.UserName == User.Identity.Name);

            var viewModel = new LabWorkViewModel
            {
                LabWork = labWork,
                LabWorkResult = labWorkResult
            };

            return View(viewModel);
        }

        public ActionResult Exercise(int id)
        {
            var exercise = db.Exercises.Include(x => x.LabWork). Include(x => x.ExerciseTests).FirstOrDefault(x => x.Id == id);
            var submissions = db.Submissions.Include(x => x.TestResults).Where(x => x.Exercise.Id == id && x.Student.User.UserName == User.Identity.Name);

            if (exercise == null)
            {
                return HttpNotFound();
            }

            var exerciseResult = db.ExerciseResults.FirstOrDefault(x => x.Exercise.Id == exercise.Id && x.Student.User.UserName == User.Identity.Name);

            var viewModel = new ExerciseViewModel
            {
                Exercise = exercise,
                Submissions = submissions,
                ExerciseResult = exerciseResult
            };
            return View(viewModel);
        }

        public ActionResult Submission(int id)
        {
            var submission = db.Submissions
                .Include(x => x.Student.User)
                .Include(x => x.Exercise)
                .Include(x => x.SubmittedContent)
                .FirstOrDefault(x => x.Id == id);

            if (submission == null)
            {
                return HttpNotFound();
            }

            if(!(submission.Student.User.UserName == User.Identity.Name || User.IsInRole("Admin")))
            {
                return HttpNotFound();
            }

            return View(submission);
        }

        [HttpPost]
        public ActionResult Submission(int id, bool isFinal)
        {
            var submission = db
                .Submissions
                .Include(x => x.Exercise)
                .Include(x => x.Student)
                .Include(x => x.TestResults)
                .FirstOrDefault(x => x.Id == id);

            if (submission == null)
            {
                return HttpNotFound();
            }

            submission.IsFinal = isFinal;
            //db.SaveChanges();

            if (isFinal)
            {
                ClearFlagForPreviousFinalSubmission(submission);
                var exerciseResult = AddExerciseResult(submission);
                AddLabWorkResult(exerciseResult);
            }
            else
            {
                RemoveExerciseResult(submission);
                RecountLabWorkResult(submission);
            }

            db.SaveChanges();

            return RedirectToAction("Submission", new {Id = id});
        }

        private void RemoveExerciseResult(Submission submission)
        {
            var exerciseResult = db.ExerciseResults.FirstOrDefault(x => x.Submission.Id == submission.Id);

            if(exerciseResult != null)
            {
                db.ExerciseResults.Remove(exerciseResult);
                db.SaveChanges();
            }
        }

        private void RecountLabWorkResult(Submission submission)
        {
            var exercise = db
                .Exercises
                .Include(x => x.LabWork)
                .FirstOrDefault(x => x.Id == submission.Exercise.Id);

            if (exercise == null)
            {
                throw new NotSupportedException();
            }

            var labWorkResult = db.LabWorkResults.FirstOrDefault(x => x.LabWork.Id == exercise.LabWork.Id);

            if (labWorkResult != null)
            {
                var mark = labWorkResult.ExerciseResults.Select(x => x.Mark).Sum();
                labWorkResult.Mark = mark;
            }            
        }

        private void ClearFlagForPreviousFinalSubmission(Submission submission)
        {
            var exerciseId = submission.Exercise.Id;
            var studentId = submission.Student.Id;
            var previousFinalSubmission = db.Submissions.FirstOrDefault(
                x => x.Exercise.Id == exerciseId
                && x.Student.Id == studentId
                && x.IsFinal);

            if (previousFinalSubmission != null)
            {
                previousFinalSubmission.IsFinal = false;
                //db.SaveChanges();
            }
        }

        private ExerciseResult AddExerciseResult(Submission submission)
        {
            var previousExerciseResult = db.ExerciseResults.FirstOrDefault(x => x.Exercise.Id == submission.Exercise.Id && x.Student.User.UserName == User.Identity.Name);

            if (previousExerciseResult != null)
            {
                db.ExerciseResults.Remove(previousExerciseResult);
                db.SaveChanges();
            }

            var passedTests = submission.TestResults.Count(x => x.IsPassed);
            var totalTests = submission.TestResults.Count;
            int mark;

            if (totalTests == 0)
            {
                mark = 0;
            }
            else{
                mark = submission.Exercise.Value * passedTests / totalTests;
            }

            var exerciseResult = new ExerciseResult
            {
                Exercise = submission.Exercise,
                Student = submission.Student,
                Submission = submission,
                Mark = mark
            };

            db.ExerciseResults.Add(exerciseResult);
            //db.SaveChanges();

            return exerciseResult;
        }

        private LabWorkResult AddLabWorkResult(ExerciseResult exerciseResult)
        {
            var exercise = db
                .Exercises
                .Include(x => x.LabWork)
                .FirstOrDefault(x => x.Id == exerciseResult.Exercise.Id);

            if(exercise == null)
            {
                throw new NotSupportedException();
            }

            var labWorkResult = db.LabWorkResults.FirstOrDefault(
                x => x.LabWork.Id == exercise.LabWork.Id
                && x.Student.Id == exerciseResult.Student.Id);

            if(labWorkResult == null)
            {
                labWorkResult = new LabWorkResult
                {
                    LabWork = exercise.LabWork,
                    ExerciseResults = new List<ExerciseResult>(),
                    Student = exerciseResult.Student
                };

                db.LabWorkResults.Add(labWorkResult);
            }
            labWorkResult.ExerciseResults.Add(exerciseResult);

            var mark = labWorkResult.ExerciseResults.Select(x => x.Mark).Sum();
            labWorkResult.Mark = mark;

            //db.SaveChanges();

            return labWorkResult;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ExerciseSubmission(ExerciseSubmissionViewModel viewModel)
        {
            bool isStatic = false; //we can call static method with instance
            if (string.IsNullOrEmpty(viewModel.Content) 
                || string.IsNullOrEmpty(viewModel.TypeName) 
                || string.IsNullOrEmpty(viewModel.MethodName))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var exercise = db.Exercises.FirstOrDefault(x => x.Id == viewModel.ExerciseId);

            if (exercise == null)
            {
                return HttpNotFound();
            }

            var submission = SaveSubmission(exercise, isStatic, viewModel);
            var taskFunctionResult = GetTaskFunction(isStatic, viewModel);
            if(taskFunctionResult.Exception == null)
            {
                var taskFunction = taskFunctionResult.TaskFunction;
                var testResults = RunTests(exercise, taskFunction);
                submission = UpdateSubmission(submission, testResults);
            }
            else
            {
                submission = UpdateSubmission(submission, taskFunctionResult.Exception);
            }

            return Json(Url.Action("Submission", "Home", new { Id = submission.Id }, Request.Url.Scheme));
        }

        private Submission SaveSubmission(Exercise exercise, bool isStatic, ExerciseSubmissionViewModel viewModel)
        {
            var currentStudent = db.Students.FirstOrDefault(x => x.User.UserName == User.Identity.Name);
            var submission = new Submission
            {
                Exercise = exercise,
                Created = DateTime.Now,
                Student = currentStudent,
                SubmittedContent = new SubmittedContent
                {
                    Content = viewModel.Content,
                    IsStatic = isStatic,
                    TypeName = viewModel.TypeName,
                    MethodName = viewModel.MethodName
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

        private Submission UpdateSubmission(Submission submission, Exception exception)
        {
            submission.TestResults = new List<ExerciseTestResult>
            {
                new ExerciseTestResult
                {
                    IsPassed = false,
                    Information = exception.Message
                }
            };

            submission.IsTested = false;

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

        private (TaskFunction TaskFunction, Exception Exception) GetTaskFunction(bool isStatic, ExerciseSubmissionViewModel viewModel)
        {
            try
            {
                var creator = new AssemblyCreator(viewModel.Content, new[] { typeof(ILogger)});
                var assembler = creator.CreateAssembly();
                var type = assembler.GetType(viewModel.TypeName);
                if (type == null)
                {
                    throw new NotSupportedException($"Type {viewModel.TypeName} not found.");
                }

                var method = type.GetMethod(viewModel.MethodName);
                if (method == null)
                {
                    throw new NotSupportedException($"Method {viewModel.MethodName} not found.");
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


                return (taskFunction, null);
            }
            catch(Exception exception)
            {
                return (null, exception);
            }
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