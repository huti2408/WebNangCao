namespace BanCaPhe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ten = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCF = c.String(),
                        soLuong = c.Int(nullable: false),
                        MaKH = c.String(maxLength: 128),
                        MaNV = c.String(maxLength: 128),
                        Tong = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThoiGian = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KhachHangs", t => t.MaKH)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaKH)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.ThucUongs",
                c => new
                    {
                        IdCF = c.String(nullable: false, maxLength: 128),
                        Ten = c.String(nullable: false),
                        HinhAnh = c.String(),
                        DonGia = c.Int(nullable: false),
                        IdLoaiNuoc = c.String(),
                        HoaDon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdCF)
                .ForeignKey("dbo.HoaDons", t => t.HoaDon_Id)
                .Index(t => t.HoaDon_Id);
            
            CreateTable(
                "dbo.LoaiNuocs",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        TenLoai = c.String(),
                        ThucUong_IdCF = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ThucUongs", t => t.ThucUong_IdCF)
                .Index(t => t.ThucUong_IdCF);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 128),
                        Ten = c.String(nullable: false),
                        MatKhau = c.String(nullable: false),
                        SDT = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 128),
                        TenNV = c.String(nullable: false),
                        MatKhau = c.String(nullable: false),
                        SDT = c.String(),
                        ViTri = c.String(),
                        Ca = c.String(),
                    })
                .PrimaryKey(t => t.MaNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDons", "MaKH", "dbo.KhachHangs");
            DropForeignKey("dbo.LoaiNuocs", "ThucUong_IdCF", "dbo.ThucUongs");
            DropForeignKey("dbo.ThucUongs", "HoaDon_Id", "dbo.HoaDons");
            DropIndex("dbo.LoaiNuocs", new[] { "ThucUong_IdCF" });
            DropIndex("dbo.ThucUongs", new[] { "HoaDon_Id" });
            DropIndex("dbo.HoaDons", new[] { "MaNV" });
            DropIndex("dbo.HoaDons", new[] { "MaKH" });
            DropTable("dbo.NhanViens");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.LoaiNuocs");
            DropTable("dbo.ThucUongs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.Admins");
        }
    }
}
