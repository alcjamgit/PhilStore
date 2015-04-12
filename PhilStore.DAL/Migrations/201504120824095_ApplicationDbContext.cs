namespace PhilStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationDbContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "CreatedBy");
        }
    }
}
