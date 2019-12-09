using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using banjiguanli.Blls.banji;
using banjiguanli.Models;

namespace banjiguanli.Controllers
{
    public class banjiController : Controller
    {
        private ClassEntities db = new ClassEntities();

        private IbanjiRepository _repository = new BanjiRepository();

        // GET: banji
        public ActionResult Index()
        {
            return View(db.banji.ToList());
        }

        // GET: banji/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banji banji = db.banji.Find(id);
            if (banji == null)
            {
                return HttpNotFound();
            }
            return View(banji);
        }

        // GET: banji/Create
        public ActionResult Create()
        {
            var teacher = db.teacher.ToList();
            ViewBag.Teacher = teacher;

            return View();
        }

        // POST: banji/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,id,Teacherid")] banji banji)
        {
            if (ModelState.IsValid)
            {
                db.banji.Add(banji);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banji);
        }

        // GET: banji/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teacher = db.teacher.ToList();
            ViewBag.Teacher = teacher;
            banji banji = db.banji.Find(id);
            if (banji == null)
            {
                return HttpNotFound();
            }
            return View(banji);
        }

        // POST: banji/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name,id,Teacherid")] banji banji)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banji).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banji);
        }

        // GET: banji/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banji banji = db.banji.Find(id);
            if (banji == null)
            {
                return HttpNotFound();
            }
            return View(banji);
        }

        // POST: banji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            banji banji = db.banji.Find(id);
            db.banji.Remove(banji);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Showkechenganpai(int id)
        { 
            return View(_repository.GetBanjiSubject(id));
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
