namespace CafeeAFM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTypeAddName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.add_coffes",
                c => new
                    {
                        id = c.Int(nullable: false),
                        add_id = c.Int(),
                        coofe_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Additions", t => t.add_id)
                .ForeignKey("dbo.Coffees", t => t.coofe_id)
                .Index(t => t.add_id)
                .Index(t => t.coofe_id);
            
            CreateTable(
                "dbo.Additions",
                c => new
                    {
                        Add_ID = c.Int(nullable: false),
                        AddType = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Add_ID);
                
            
            CreateTable(
                "dbo.add_sweets",
                c => new
                    {
                        id = c.Int(nullable: false),
                        add_id = c.Int(),
                        sweet_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Additions", t => t.add_id)
                .ForeignKey("dbo.Sweets", t => t.sweet_id)
                .Index(t => t.add_id)
                .Index(t => t.sweet_id);
            
            CreateTable(
                "dbo.Sweets",
                c => new
                    {
                        SweetID = c.Int(nullable: false),
                        SweetName = c.String(maxLength: 50),
                        SweetPrice = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.SweetID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ServiceID = c.Int(),
                        Coffee_ID = c.Int(),
                        SweetID = c.Int(),
                        TableNumber = c.Int(),
                        Quantity = c.Int(),
                        Total_Price = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Coffees", t => t.Coffee_ID)
                .ForeignKey("dbo.Services", t => t.ServiceID)
                .ForeignKey("dbo.Sweets", t => t.SweetID)
                .Index(t => t.ServiceID)
                .Index(t => t.Coffee_ID)
                .Index(t => t.SweetID);
            
            CreateTable(
                "dbo.Coffees",
                c => new
                    {
                        Coffee_ID = c.Int(nullable: false),
                        CoffeeName = c.String(maxLength: 50),
                        CoffeePrice = c.Decimal(storeType: "money"),
                        CoffeeSize = c.String(),
                    })
                .PrimaryKey(t => t.Coffee_ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false),
                        BookID = c.Int(),
                        Wifi_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.Book_Infos", t => t.BookID)
                .ForeignKey("dbo.Wifi_Infos", t => t.Wifi_ID)
                .Index(t => t.BookID)
                .Index(t => t.Wifi_ID);
            
            CreateTable(
                "dbo.Book_Infos",
                c => new
                    {
                        Book_ID = c.Int(nullable: false),
                        Bookname = c.String(maxLength: 50),
                        BookType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Book_ID)
                .ForeignKey("dbo.BookTypes", t => t.BookType_ID)
                .Index(t => t.BookType_ID);
            
            CreateTable(
                "dbo.BookTypes",
                c => new
                    {
                        BookType_ID = c.Int(nullable: false),
                        BookTypeName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BookType_ID);
            
            CreateTable(
                "dbo.Wifi_Infos",
                c => new
                    {
                        Wifi_ID = c.Int(nullable: false),
                        Wifi_Period = c.String(maxLength: 50),
                        Wifi_Price = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.Wifi_ID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Admin_ID = c.Int(nullable: false),
                        AdminName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Admin_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "SweetID", "dbo.Sweets");
            DropForeignKey("dbo.Services", "Wifi_ID", "dbo.Wifi_Infos");
            DropForeignKey("dbo.Orders", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "BookID", "dbo.Book_Infos");
            DropForeignKey("dbo.Book_Infos", "BookType_ID", "dbo.BookTypes");
            DropForeignKey("dbo.Orders", "Coffee_ID", "dbo.Coffees");
            DropForeignKey("dbo.add_coffes", "coofe_id", "dbo.Coffees");
            DropForeignKey("dbo.add_sweets", "sweet_id", "dbo.Sweets");
            DropForeignKey("dbo.add_sweets", "add_id", "dbo.Additions");
            DropForeignKey("dbo.add_coffes", "add_id", "dbo.Additions");
            DropIndex("dbo.Book_Infos", new[] { "BookType_ID" });
            DropIndex("dbo.Services", new[] { "Wifi_ID" });
            DropIndex("dbo.Services", new[] { "BookID" });
            DropIndex("dbo.Orders", new[] { "SweetID" });
            DropIndex("dbo.Orders", new[] { "Coffee_ID" });
            DropIndex("dbo.Orders", new[] { "ServiceID" });
            DropIndex("dbo.add_sweets", new[] { "sweet_id" });
            DropIndex("dbo.add_sweets", new[] { "add_id" });
            DropIndex("dbo.add_coffes", new[] { "coofe_id" });
            DropIndex("dbo.add_coffes", new[] { "add_id" });
            DropTable("dbo.Admins");
            DropTable("dbo.Wifi_Infos");
            DropTable("dbo.BookTypes");
            DropTable("dbo.Book_Infos");
            DropTable("dbo.Services");
            DropTable("dbo.Coffees");
            DropTable("dbo.Orders");
            DropTable("dbo.Sweets");
            DropTable("dbo.add_sweets");
            DropTable("dbo.Additions");
            DropTable("dbo.add_coffes");
        }
    }
}
