namespace aspnet_tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(unicode: false),
                        CreatedAt = c.DateTime(precision: 0),
                        UpdatedAt = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(),
                        ProductName = c.String(unicode: false),
                        UnitPrice = c.Double(nullable: false),
                        CreatedAt = c.DateTime(precision: 0),
                        UpdatedAt = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Tel = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        CreatedAt = c.DateTime(precision: 0),
                        UpdatedAt = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        ProductId = c.Int(),
                        Qty = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        CreatedAt = c.DateTime(precision: 0),
                        UpdatedAt = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
