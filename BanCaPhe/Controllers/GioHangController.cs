using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanCaPhe.Models;

namespace BanCaPhe.Controllers
{
    public class GioHangController : Controller
    {
        CaPheContext db = new CaPheContext();
        // GET: GioHang
        public ActionResult ShowCart()
        {
            if (Session["khachhang"] == null)
                return RedirectToAction("Index", "SanPham");
            if (Session["Cart"] == null)
                return RedirectToAction("Index", "SanPham");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult ThemVaoGio(string id)
        {
            var cf = db.ThucUongs.SingleOrDefault(s => s.IdCF == id);
            if(cf != null)
            {
                GetCart().ThemVaoGioHang(cf);
            }
            return RedirectToAction("ShowCart", "GioHang");
        }
        public ActionResult UpdateSoLuong(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            string id = form["Id"].ToString();
            int soluong = int.Parse(form["SoLuong"]);
            cart.UpdateSL(id, soluong);
            return RedirectToAction("ShowCart", "GioHang");
        }
        public ActionResult XoaItem(string id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Xoa(id);
            return RedirectToAction("ShowCart", "GioHang");
        }
        public int Randomid(int min,int max)
        {
            
            Random random = new Random();
            int res =  random.Next(min, max);
            if(db.HoaDons.Where(s=>s.Id == res) != null) return random.Next(min,max);
            
                
            
            return res;
        }
        public ActionResult ThanhToan(FormCollection form)
        {
            try
            {
                
                Cart cart = Session["Cart"] as Cart;   
                if(cart.Items.Count() == 0)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                HoaDon hoadon = new HoaDon();
                
                hoadon.ThoiGian = DateTime.Now;
                hoadon.MaKH = Session["IdKH"].ToString();
                hoadon.DiaChiGiao = form["DCGiao"].ToString();
                hoadon.Tong = cart.TongTien();
               
                db.HoaDons.Add(hoadon);
                db.SaveChanges();
                TempData["IdHoaDon"] = hoadon.Id;
                cart.ghichu = form["ghichu"].ToString();
                
                foreach (var item in cart.Items)
                {
                    ChiTietHD cthd = new ChiTietHD();
                    cthd.IdHD = hoadon.Id;
                    cthd.IdCF = item.thucUong.IdCF;
                    cthd.soLuong = item.soluong;
                    cthd.ghiChu = cart.ghichu;
                    cthd.Thanhtien = item.soluong * item.thucUong.DonGia;
                    db.ChiTietHDs.Add(cthd);
                    db.SaveChanges();
                }
                
                TempData["sdt"] = form["SDT"].ToString();
                TempData["DiaChi"] = hoadon.DiaChiGiao;

                cart.Clear();
                    
                    return RedirectToAction("ThanhToanThanhCong");                            
            }
            catch
            {
                return Content("Lỗi, vui lòng kiểm tra lại thông tin đơn hàng");
            }            
        }
        public ActionResult ThanhToanThanhCong()
        {
            
            return View();
        }
    }
}