namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Autoes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Autoes", "Description");
        }
    }
}
