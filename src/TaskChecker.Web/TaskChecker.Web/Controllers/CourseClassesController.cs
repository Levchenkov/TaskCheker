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
    public class CourseClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseClasses
        public ActionResult Index()
        {
            return View(db.CourseClasses.ToList());
        }

        // GET: CourseClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseClass courseClass = db.CourseClasses.Find(id);
            if (courseClass == null)
            {
                return HttpNotFound();
            }
            return View(courseClass);
        }

        // GET: CourseClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,IsOpened")] CourseClass courseClass)
        {
            if (ModelState.IsValid)
            {
                db.CourseClasses.Add(courseClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseClass);
        }

        // GET: CourseClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseClass courseClass = db.CourseClasses.Find(id);
            if (courseClass == null)
            {
                return HttpNotFound();
            }
            return View(courseClass);
        }

        // POST: CourseClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IsOpened")] CourseClass courseClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseClass);
        }

        // GET: CourseClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseClass courseClass = db.CourseClasses.Find(id);
            if (courseClass == null)
            {
                return HttpNotFound();
            }
            return View(courseClass);
        }

        // POST: CourseClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseClass courseClass = db.CourseClasses.Find(id);
            db.CourseClasses.Remove(courseClass);
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
