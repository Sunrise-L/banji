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
    public class kechenganpaiController : Controller
    {
        private ClassEntities db = new ClassEntities();

        // GET: kechenganpai
        public ActionResult Index()
        {
            return View(db.kechenganpai.ToList());
        }

        // GET: kechenganpai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kechenganpai kechenganpai = db.kechenganpai.Find(id);
            if (kechenganpai == null)
            {
                return HttpNotFound();
            }
            return View(kechenganpai);
        }

        // GET: kechenganpai/Create
        public ActionResult Create()
        {

            var banji = db.banji.ToList();
            ViewBag.Banji = banji;
            var subject = db.subject.ToList();
            ViewBag.Subject = subject;
            var teacher = db.teacher.ToList();
            ViewBag.Teacher = teacher;

            return View();
        }

        // POST: kechenganpai/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubjectId,BanjiId,TeacherId")] kechenganpai kechenganpai)
        {
            if (ModelState.IsValid)
            {
                db.kechenganpai.Add(kechenganpai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kechenganpai);
        }

        // GET: kechenganpai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kechenganpai kechenganpai = db.kechenganpai.Find(id);
            if (kechenganpai == null)
            {
                return HttpNotFound();
            }
            return View(kechenganpai);
        }

        // POST: kechenganpai/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubjectId,BanjiId,TeacherId")] kechenganpai kechenganpai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kechenganpai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kechenganpai);
        }

        // GET: kechenganpai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kechenganpai kechenganpai = db.kechenganpai.Find(id);
            if (kechenganpai == null)
            {
                return HttpNotFound();
            }
            return View(kechenganpai);
        }

        // POST: kechenganpai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kechenganpai kechenganpai = db.kechenganpai.Find(id);
            db.kechenganpai.Remove(kechenganpai);
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
