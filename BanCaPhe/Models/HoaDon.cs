using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BanCaPhe.Models
{
    public class HoaDon
    {
        public int Id { get; set; }  
        public string MaKH { get; set; }
        public string MaNV { get; set; }
       
        public decimal Tong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ giao")]
        public string DiaChiGiao { get; set; }
        public DateTime ThoiGian { get; set; }   
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}