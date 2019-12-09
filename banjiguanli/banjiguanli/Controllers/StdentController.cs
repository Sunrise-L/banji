using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using banjiguanli.Models;

namespace banjiguanli.Controllers
{
    public class StdentController : Controller
    {
        private ClassEntities db = new ClassEntities();

        // GET: Stdent
        public ActionResult Index()
        {
            return View(db.Stdent.ToList());
        }

        // GET: Stdent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stdent stdent = db.Stdent.Find(id);
            if (stdent == null)
            {
                return HttpNotFound();
            }
            return View(stdent);
        }

        // GET: Stdent/Create
        public ActionResult Create()
        {
            var banji = db.banji.ToList();
            ViewBag.Banji = banji;
            return View();
        }

        // POST: Stdent/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Classid")] Stdent stdent)
        {
            if (ModelState.IsValid)
            {
                db.Stdent.Add(stdent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stdent);
        }

        // GET: Stdent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stdent stdent = db.Stdent.Find(id);
            if (stdent == null)
            {
                return HttpNotFound();
            }
            return View(stdent);
        }

        // POST: Stdent/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Classid")] Stdent stdent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stdent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stdent);
        }

        // GET: Stdent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stdent stdent = db.Stdent.Find(id);
            if (stdent == null)
            {
                return HttpNotFound();
            }
            return View(stdent);
        }

        // POST: Stdent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stdent stdent = db.Stdent.Find(id);
            db.Stdent.Remove(stdent);
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
