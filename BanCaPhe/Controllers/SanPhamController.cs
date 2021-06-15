using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;
using System.Web.Mvc;
using BanCaPhe.Models;

namespace BanCaPhe.Controllers
{
    public class SanPhamController : Controller
    {
        CaPheContext db = new CaPheContext();
        // GET: SanPham
        public ActionResult Index(int? page, string loai, string search)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
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
        public ActionResult DangNhap(KhachHang khach)
        {
            ModelState.AddModelError("MatKhau", "Sai mật khẩu");
            ModelState.AddModelError("MaKH", "Người dùng không tồn tại");
            var kh = db.KhachHangs.Where(user => user.MaKH == khach.MaKH && user.MatKhau == khach.MatKhau).FirstOrDefault();
            if(kh != null)
            {
                Session["khachhang"] = kh.Ten.ToString();
                Session["IdKH"] = kh.MaKH;
                Session["DiaChi"] = kh.DiaChi;
                Session["SDT"] = kh.SDT;
                return RedirectToAction("Index");
            }
            return View(khach);
        }
        public ActionResult DangKy(KhachHang khach)
        {
            if (ModelState.IsValid)
            {
                var ID = db.KhachHangs.Where(s => s.MaKH == khach.MaKH).FirstOrDefault();
                if (ID == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(khach);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap");
                }
                else
                {
                    ViewBag.ErrorRegister = "This username is exist";
                    return View();
                }
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public PartialViewResult LoaiNuoc()
        {
            return PartialView(db.LoaiNuocs.ToList());
        }
    }
}