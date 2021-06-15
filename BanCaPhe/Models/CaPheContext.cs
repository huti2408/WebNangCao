using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BanCaPhe.Models
{
    public class CaPheContext: DbContext
    {
        public CaPheContext() : base("CFDb")
        {

        }     
        public DbSet<ThucUong> ThucUongs { get; set; }                      
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }                   
        public DbSet<LoaiNuoc> LoaiNuocs { get; set; }
        public DbSet<ChiTietHD> ChiTietHDs { get; set; }
}
}