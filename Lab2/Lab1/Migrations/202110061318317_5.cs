namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            AddColumn("dbo.Products", "AutoModel", c => c.String());
            AddColumn("dbo.Products", "Manufacturer", c => c.String());
            AddColumn("dbo.Products", "Year", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "ProductName");
            DropColumn("dbo.Products", "Description");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PIB = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        ProductNumber = c.Int(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "ProductName", c => c.String());
            DropColumn("dbo.Products", "Year");
            DropColumn("dbo.Products", "Manufacturer");
            DropColumn("dbo.Products", "AutoModel");
            CreateIndex("dbo.Orders", "Product_Id");
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id");
        }
    }
}
