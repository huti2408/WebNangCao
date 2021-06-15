using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanCaPhe.Models
{
    public class CartItem
    {
        public ThucUong thucUong { get; set; }
        public int soluong { get; set; }
       
    }
    public class Cart 
    {
        public string ghichu { get; set; }
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void ThemVaoGioHang(ThucUong thuc, int solg = 1)
        {
            var item = Items.FirstOrDefault(s => s.thucUong.IdCF == thuc.IdCF);
            if (item == null)
                items.Add(new CartItem
                {
                    thucUong = thuc,
                    soluong = solg
                });
            else
                item.soluong += solg;
        }
        public int TongSL()
        {
            return items.Sum(s => s.soluong);
        }
        public int TongTien()
        {
            var total = items.Sum(s => s.soluong * s.thucUong.DonGia);
            return (int)total;
        }   
        public void Xoa(string id)
        {
            items.RemoveAll(s => s.thucUong.IdCF==id);
        }
        public void Clear()
        {
            items.Clear();
        }
        public void UpdateSL(string id, int newSL)
        {
            var item = items.Find(s => s.thucUong.IdCF == id);
            if(item != null)
            {
                item.soluong = newSL;
            }
        }
    }
}