namespace Lab4_5_6_7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
        }
    }
}
