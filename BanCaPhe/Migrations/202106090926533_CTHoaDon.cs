namespace BanCaPhe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CTHoaDon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ThucUongs", "HoaDon_Id", "dbo.HoaDons");
            DropIndex("dbo.ThucUongs", new[] { "HoaDon_Id" });
            CreateTable(
                "dbo.ChiTietHDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCF = c.String(),
                        soLuong = c.Int(nullable: false),
                        Thanhtien = c.Int(nullable: false),
                        ghiChu = c.String(),
                        IdHD = c.String(),
                        HoaDon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoaDons", t => t.HoaDon_Id)
                .Index(t => t.HoaDon_Id);
            
            AddColumn("dbo.HoaDons", "IdCTHD", c => c.Int(nullable: false));
            AddColumn("dbo.ThucUongs", "ChiTietHD_Id", c => c.Int());
            CreateIndex("dbo.ThucUongs", "ChiTietHD_Id");
            AddForeignKey("dbo.ThucUongs", "ChiTietHD_Id", "dbo.ChiTietHDs", "Id");
            DropColumn("dbo.HoaDons", "IdCF");
            DropColumn("dbo.HoaDons", "soLuong");
            DropColumn("dbo.ThucUongs", "HoaDon_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ThucUongs", "HoaDon_Id", c => c.Int());
            AddColumn("dbo.HoaDons", "soLuong", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDons", "IdCF", c => c.String());
            DropForeignKey("dbo.ChiTietHDs", "HoaDon_Id", "dbo.HoaDons");
            DropForeignKey("dbo.ThucUongs", "ChiTietHD_Id", "dbo.ChiTietHDs");
            DropIndex("dbo.ThucUongs", new[] { "ChiTietHD_Id" });
            DropIndex("dbo.ChiTietHDs", new[] { "HoaDon_Id" });
            DropColumn("dbo.ThucUongs", "ChiTietHD_Id");
            DropColumn("dbo.HoaDons", "IdCTHD");
            DropTable("dbo.ChiTietHDs");
            CreateIndex("dbo.ThucUongs", "HoaDon_Id");
            AddForeignKey("dbo.ThucUongs", "HoaDon_Id", "dbo.HoaDons", "Id");
        }
    }
}
