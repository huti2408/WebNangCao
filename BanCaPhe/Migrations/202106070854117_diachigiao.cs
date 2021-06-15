namespace BanCaPhe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diachigiao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoaDons", "DiaChiGiao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoaDons", "DiaChiGiao");
        }
    }
}
