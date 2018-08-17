using System;
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
    public class ExerciseTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExerciseTests
        public ActionResult Index()
        {
            return View(db.ExerciseTests.ToList());
        }

        // GET: ExerciseTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseTest exerciseTest = db.ExerciseTests.Find(id);
            if (exerciseTest == null)
            {
                return HttpNotFound();
            }
            return View(exerciseTest);
        }

        // GET: ExerciseTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExerciseTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeName,IsEnabled")] ExerciseTest exerciseTest)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseTests.Add(exerciseTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exerciseTest);
        }

        // GET: ExerciseTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseTest exerciseTest = db.ExerciseTests.Find(id);
            if (exerciseTest == null)
            {
                return HttpNotFound();
            }
            return View(exerciseTest);
        }

        // POST: ExerciseTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeName,IsEnabled")] ExerciseTest exerciseTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exerciseTest);
        }

        // GET: ExerciseTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseTest exerciseTest = db.ExerciseTests.Find(id);
            if (exerciseTest == null)
            {
                return HttpNotFound();
            }
            return View(exerciseTest);
        }

        // POST: ExerciseTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseTest exerciseTest = db.ExerciseTests.Find(id);
            db.ExerciseTests.Remove(exerciseTest);
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
