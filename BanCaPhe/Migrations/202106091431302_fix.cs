namespace BanCaPhe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ThucUongs", "ChiTietHD_Id", "dbo.ChiTietHDs");
            DropIndex("dbo.ThucUongs", new[] { "ChiTietHD_Id" });
            AlterColumn("dbo.ChiTietHDs", "IdCF", c => c.String(maxLength: 128));
            CreateIndex("dbo.ChiTietHDs", "IdCF");
            AddForeignKey("dbo.ChiTietHDs", "IdCF", "dbo.ThucUongs", "IdCF");
            DropColumn("dbo.HoaDons", "IdCTHD");
            DropColumn("dbo.ChiTietHDs", "IdHD");
            DropColumn("dbo.ThucUongs", "ChiTietHD_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ThucUongs", "ChiTietHD_Id", c => c.Int());
            AddColumn("dbo.ChiTietHDs", "IdHD", c => c.String());
            AddColumn("dbo.HoaDons", "IdCTHD", c => c.Int(nullable: false));
            DropForeignKey("dbo.ChiTietHDs", "IdCF", "dbo.ThucUongs");
            DropIndex("dbo.ChiTietHDs", new[] { "IdCF" });
            AlterColumn("dbo.ChiTietHDs", "IdCF", c => c.String());
            CreateIndex("dbo.ThucUongs", "ChiTietHD_Id");
            AddForeignKey("dbo.ThucUongs", "ChiTietHD_Id", "dbo.ChiTietHDs", "Id");
        }
    }
}
