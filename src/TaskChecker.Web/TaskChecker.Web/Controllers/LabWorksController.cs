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
    public class LabWorksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LabWorks
        public ActionResult Index()
        {
            return View(db.LabWorks.ToList());
        }

        public ActionResult Results(int id)
        {
            ViewBag.LabWorkId = id;
            var results = db.LabWorkResults.Include(x => x.Student).Where(x => x.LabWork.Id == id);

            return View(results);
        }

        // GET: LabWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabWork labWork = db.LabWorks.Find(id);
            if (labWork == null)
            {
                return HttpNotFound();
            }
            return View(labWork);
        }

        // GET: LabWorks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsOpened,DueDate")] LabWork labWork)
        {
            if (ModelState.IsValid)
            {
                db.LabWorks.Add(labWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labWork);
        }

        // GET: LabWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabWork labWork = db.LabWorks.Include(x => x.Exercises).FirstOrDefault(x => x.Id == id);
            if (labWork == null)
            {
                return HttpNotFound();
            }

            var selectedExercises = labWork.Exercises.Select(x => x.Id).ToArray();

            var exercises = db.Exercises.Select(x => new
            {
                Id = x.Id,
                Value = x.Name
            }).ToList();

            ViewBag.Exercises = new MultiSelectList(exercises, "Id", "Value", selectedExercises);

            return View(labWork);
        }

        // POST: LabWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsOpened,DueDate")] LabWork labWork, int[] exerciseIds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labWork).State = EntityState.Modified;
                db.SaveChanges();

                labWork = db.LabWorks.Include(x => x.Exercises).FirstOrDefault(x => x.Id == labWork.Id);

                if (exerciseIds == null)
                {
                    labWork.Exercises.Clear();
                }
                else
                {
                    var selectedExercises = db.Exercises.Where(x => exerciseIds.Contains(x.Id)).ToList();
                    labWork.Exercises = selectedExercises;
                }
                db.SaveChanges();
                
                return RedirectToAction("Details", new { labWork.Id });
            }
            return View(labWork);
        }

        // GET: LabWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabWork labWork = db.LabWorks.Find(id);
            if (labWork == null)
            {
                return HttpNotFound();
            }
            return View(labWork);
        }

        // POST: LabWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabWork labWork = db.LabWorks.Find(id);
            db.LabWorks.Remove(labWork);
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
