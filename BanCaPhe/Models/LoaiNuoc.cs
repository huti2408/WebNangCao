using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanCaPhe.Models
{
    public class LoaiNuoc
    {
        public string id { get; set; }
        public string TenLoai { get; set; }
        public virtual ThucUong ThucUong { get; set; }
    }
}