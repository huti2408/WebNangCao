using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanCaPhe.Models
{
    public class ChiTietHD
    {
        public int Id { get; set; }
        public string IdCF { get; set; }
        public int IdHD { get; set; }
        public int soLuong { get; set; }
        public int Thanhtien { get; set; }
        public string ghiChu { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual ThucUong ThucUong { get; set; }
    }
}