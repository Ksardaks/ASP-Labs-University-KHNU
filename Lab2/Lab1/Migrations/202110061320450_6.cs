namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "Autoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Autoes", newName: "Products");
        }
    }
}
