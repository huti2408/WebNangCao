using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using BanCaPhe.Models;

namespace BanCaPhe.Controllers
{
    public class KhachHangController : Controller
    {
        CaPheContext db = new CaPheContext();
        public bool AuthCheck(string perm)
        {
            bool check = true;

            if (Session["username"] == null)
                return check = false;

            if (!String.IsNullOrEmpty(perm))
            {
                if (!Session["username"].Equals(perm))
                    check = false;
                if (Session["username"].Equals("admin"))
                    check = true;
            }
            return check;
        }
        // GET: KhachHang
        public ActionResult Index()
        {
            if (!AuthCheck("Admin"))
                return RedirectToAction("Index", "QuanLy");
            return View(db.KhachHangs.ToList());
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,Ten,MatKhau,SDT,DiaChi")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }
    }
}