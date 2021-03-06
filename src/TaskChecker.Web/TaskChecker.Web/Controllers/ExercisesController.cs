﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskChecker.Web.Database;
using TaskChecker.Web.Models.Entities;

namespace TaskChecker.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExercisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exercises
        public ActionResult Index()
        {
            return View(db.Exercises.Include(x => x.ExerciseTests).ToList());
        }

        public ActionResult Results(int id)
        {
            ViewBag.ExerciseId = id;
            var results = db.ExerciseResults
                .Include(x => x.Student)
                .Include(x => x.Submission)
                .Where(x => x.Exercise.Id == id)
                .ToList()
                .OrderBy(x => x.Student.FullName);

            return View(results);
        }

        // GET: Exercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Value,IsStatic,TypeName,MethodName")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Exercises.Add(exercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }

            var selectedTests = exercise.ExerciseTests.Select(x => x.Id).ToArray();

            var exerciseTests = db.ExerciseTests.Select(x => new
            {
                Id = x.Id,
                Value = x.TypeName
            }).ToList();

            ViewBag.ExerciseTests = new MultiSelectList(exerciseTests, "Id", "Value", selectedTests);

            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Name,Description,Value,IsStatic,TypeName,MethodName")] Exercise exercise, 
            int[] exerciseTestIds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();

                exercise = db.Exercises.Include(x => x.ExerciseTests).FirstOrDefault(x => x.Id == exercise.Id);

                if(exerciseTestIds == null)
                {
                    exercise.ExerciseTests.Clear();
                }
                else
                {
                    var selectedTests = db.ExerciseTests.Where(x => exerciseTestIds.Contains(x.Id)).ToList();
                    exercise.ExerciseTests = selectedTests;
                }
                db.SaveChanges();

                return RedirectToAction("Details", new { exercise.Id });
            }
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            db.Exercises.Remove(exercise);
            db.SaveChanges();
            return RedirectToAction("Index");
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
