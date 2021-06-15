namespace BanCaPhe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HoaDons", "DiaChiGiao", c => c.String(nullable: false));
            AlterColumn("dbo.ThucUongs", "HinhAnh", c => c.String(nullable: false));
            AlterColumn("dbo.ThucUongs", "IdLoaiNuoc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ThucUongs", "IdLoaiNuoc", c => c.String());
            AlterColumn("dbo.ThucUongs", "HinhAnh", c => c.String());
            AlterColumn("dbo.HoaDons", "DiaChiGiao", c => c.String());
        }
    }
}
