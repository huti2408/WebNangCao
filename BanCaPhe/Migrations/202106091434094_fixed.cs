namespace BanCaPhe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _fixed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChiTietHDs", "IdHD", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChiTietHDs", "IdHD");
        }
    }
}
