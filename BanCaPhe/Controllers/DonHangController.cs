using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using BanCaPhe.Models;
namespace BanCaPhe.Controllers
{
    public class DonHangController : Controller
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
        // GET: DonHang
        public ActionResult Index(int? page)
        {
            if (!AuthCheck("Admin"))
                return RedirectToAction("Index", "QuanLy");
            int pageSize = 10;
            int pageNum = (page ?? 1);
            return View(db.HoaDons.ToList().ToPagedList(pageNum,pageSize));
        }
        public ActionResult ChiTiet(int id)
        {
            
            return View(db.ChiTietHDs.Where(s=>s.IdHD == id).ToList());
        }
    }
}