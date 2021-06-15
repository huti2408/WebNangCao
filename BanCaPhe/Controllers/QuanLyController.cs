using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using PagedList.Mvc;
using PagedList;
using BanCaPhe.Models;
using System.Data.Entity;

namespace BanCaPhe.Controllers
{
    public class QuanLyController : Controller
    {
        CaPheContext db = new CaPheContext();
        // GET: QuanLy
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
        public ActionResult Index(string search, string loai, int? page)
        {
            int pageSize = 6;
            int pageNum = (page?? 1);
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            }
            var cf = from m in db.ThucUongs select m;

            if (loai != null)
            {
                cf = db.ThucUongs.Where(s => s.IdLoaiNuoc == loai);
            }          
            if (!string.IsNullOrEmpty(search))
            {
                cf = cf.Where(s => s.Ten.Contains(search));               
            }
            
            return View(cf.OrderBy(s=>s.Ten).ToPagedList(pageNum,pageSize));
        }
        public PartialViewResult LoaiNuoc()
        {
            var loai = db.LoaiNuocs.ToList();
            return PartialView(loai);
        }
       
        public ActionResult Create()
        {
            if (!AuthCheck("Admin"))
                return RedirectToAction("Index", "QuanLy");
            var loainuoc = db.LoaiNuocs.ToList();
            ViewBag.loaiNuoc = new SelectList(loainuoc, "id", "TenLoai");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ThucUong cf)
        {
            try
            {
                db.ThucUongs.Add(cf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
        
        [HttpPost]        
        public ActionResult DeleteSP(FormCollection form)
        {

            string id = form["idCF_Delete"].ToString();
            ThucUong cf = db.ThucUongs.Where(s => s.IdCF == id).FirstOrDefault();
            
            if (cf == null)
            {
                return HttpNotFound();
            }
            db.ThucUongs.Remove(cf);
            db.SaveChanges(); 
            return RedirectToAction("Index", "QuanLy");
        }
        public ActionResult Login(NhanVien ad)
        {
            ModelState.AddModelError("MaNV", "Người dùng không tồn tại");
            ModelState.AddModelError("MatKhau", "Sai mật khẩu");
            
            var currentad = db.NhanViens.Where(user => user.MaNV == ad.MaNV && user.MatKhau == ad.MatKhau).FirstOrDefault();
            if (currentad != null)
            {
                Session["username"] = currentad.TenNV.ToString();
                return RedirectToAction("Index");
            }                         
                return View(ad);       
        }
        public ActionResult DangXuat()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                var ID = db.NhanViens.Where(s => s.MaNV == nv.MaNV).FirstOrDefault();
                if (ID == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.NhanViens.Add(nv);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exist";
                    return View();
                }
            }
            return View();
        }
        public ActionResult EditSP(string id)
        {
            if (!AuthCheck("Admin"))
                return RedirectToAction("Index", "QuanLy");
            var loainuoc = db.LoaiNuocs.ToList();
            ViewBag.loaiNuoc = new SelectList(loainuoc, "id", "TenLoai");
            ThucUong cf = db.ThucUongs.Find(id);
            if (cf == null)
                return RedirectToAction("Index", "QuanLy");
            return View(cf);
        }
        [HttpPost]
        public ActionResult EditSP([Bind(Include ="IdCF,Ten,HinhAnh,DonGia,IdLoaiNuoc")] ThucUong cf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cf);
        }
        
        
    }
}