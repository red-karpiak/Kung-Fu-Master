using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kung_Fu_Tracker.Models;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class PatternLinesMvcController : Controller
    {
        private PatternLinesContext db = new PatternLinesContext();

        // GET: PatternLinesMvc
        public ActionResult Index()
        {
            return View(db.PatternLines.ToList());
        }

        // GET: PatternLinesMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatternLine patternLine = db.PatternLines.Find(id);
            if (patternLine == null)
            {
                return HttpNotFound();
            }
            return View(patternLine);
        }

        // GET: PatternLinesMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatternLinesMvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rank,Order,Feet,LeftHand,RightHand")] PatternLine patternLine)
        {
            if (ModelState.IsValid)
            {
                db.PatternLines.Add(patternLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patternLine);
        }

        // GET: PatternLinesMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatternLine patternLine = db.PatternLines.Find(id);
            if (patternLine == null)
            {
                return HttpNotFound();
            }
            return View(patternLine);
        }

        // POST: PatternLinesMvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rank,Order,Feet,LeftHand,RightHand")] PatternLine patternLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patternLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patternLine);
        }

        // GET: PatternLinesMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatternLine patternLine = db.PatternLines.Find(id);
            if (patternLine == null)
            {
                return HttpNotFound();
            }
            return View(patternLine);
        }

        // POST: PatternLinesMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatternLine patternLine = db.PatternLines.Find(id);
            db.PatternLines.Remove(patternLine);
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
