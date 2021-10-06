namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Autoes", "Options", c => c.String());
            AddColumn("dbo.Autoes", "Complection", c => c.String());
            AddColumn("dbo.Autoes", "Characteristic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Autoes", "Characteristic");
            DropColumn("dbo.Autoes", "Complection");
            DropColumn("dbo.Autoes", "Options");
        }
    }
}
