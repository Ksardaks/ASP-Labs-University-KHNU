﻿namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "File");
        }
    }
}
