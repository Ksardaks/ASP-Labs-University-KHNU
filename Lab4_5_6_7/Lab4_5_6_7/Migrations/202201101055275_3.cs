namespace Lab4_5_6_7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryNameEN", c => c.String());
            AddColumn("dbo.Products", "ProductNameEN", c => c.String());
            AddColumn("dbo.Products", "PriceEN", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PriceEN");
            DropColumn("dbo.Products", "ProductNameEN");
            DropColumn("dbo.Categories", "CategoryNameEN");
        }
    }
}
