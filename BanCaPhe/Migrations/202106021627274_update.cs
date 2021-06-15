namespace BanCaPhe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoaDons", "MaKH", "dbo.KhachHangs");
            DropForeignKey("dbo.HoaDons", "MaNV", "dbo.NhanViens");
            DropIndex("dbo.HoaDons", new[] { "MaKH" });
            DropIndex("dbo.HoaDons", new[] { "MaNV" });
            DropPrimaryKey("dbo.KhachHangs");
            DropPrimaryKey("dbo.NhanViens");
            AlterColumn("dbo.HoaDons", "MaKH", c => c.String(maxLength: 15));
            AlterColumn("dbo.HoaDons", "MaNV", c => c.String(maxLength: 15));
            AlterColumn("dbo.KhachHangs", "MaKH", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.KhachHangs", "MatKhau", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.KhachHangs", "SDT", c => c.String(maxLength: 11));
            AlterColumn("dbo.NhanViens", "MaNV", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.NhanViens", "MatKhau", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.NhanViens", "SDT", c => c.String(maxLength: 11));
            AddPrimaryKey("dbo.KhachHangs", "MaKH");
            AddPrimaryKey("dbo.NhanViens", "MaNV");
            CreateIndex("dbo.HoaDons", "MaKH");
            CreateIndex("dbo.HoaDons", "MaNV");
            AddForeignKey("dbo.HoaDons", "MaKH", "dbo.KhachHangs", "MaKH");
            AddForeignKey("dbo.HoaDons", "MaNV", "dbo.NhanViens", "MaNV");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDons", "MaKH", "dbo.KhachHangs");
            DropIndex("dbo.HoaDons", new[] { "MaNV" });
            DropIndex("dbo.HoaDons", new[] { "MaKH" });
            DropPrimaryKey("dbo.NhanViens");
            DropPrimaryKey("dbo.KhachHangs");
            AlterColumn("dbo.NhanViens", "SDT", c => c.String());
            AlterColumn("dbo.NhanViens", "MatKhau", c => c.String(nullable: false));
            AlterColumn("dbo.NhanViens", "MaNV", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.KhachHangs", "SDT", c => c.String());
            AlterColumn("dbo.KhachHangs", "MatKhau", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "MaKH", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.HoaDons", "MaNV", c => c.String(maxLength: 128));
            AlterColumn("dbo.HoaDons", "MaKH", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.NhanViens", "MaNV");
            AddPrimaryKey("dbo.KhachHangs", "MaKH");
            CreateIndex("dbo.HoaDons", "MaNV");
            CreateIndex("dbo.HoaDons", "MaKH");
            AddForeignKey("dbo.HoaDons", "MaNV", "dbo.NhanViens", "MaNV");
            AddForeignKey("dbo.HoaDons", "MaKH", "dbo.KhachHangs", "MaKH");
        }
    }
}
