namespace Wings.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chanel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChanelName = c.String(nullable: false, maxLength: 20),
                        EnglishName = c.String(nullable: false),
                        ChanelType = c.Int(nullable: false),
                        ChanelIndex = c.Int(nullable: false),
                        WId = c.Int(nullable: false),
                        UId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WebSite", t => t.WId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UId, cascadeDelete: true)
                .Index(t => t.WId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        EnglishTitle = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Url = c.String(nullable: false, maxLength: 500),
                        Img = c.String(maxLength: 500),
                        Data = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Tag = c.String(maxLength: 100),
                        CId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chanel", t => t.CId, cascadeDelete: true)
                .Index(t => t.CId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 1000),
                        CreateTime = c.DateTime(nullable: false),
                        Eamil = c.String(),
                        NickName = c.String(),
                        UId = c.Int(nullable: false),
                        CId = c.Int(nullable: false),
                        PId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Content", t => t.CId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UId)
                .Index(t => t.CId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 30),
                        PassWord = c.String(maxLength: 32),
                        LogIp = c.String(maxLength: 15),
                        LogTime = c.DateTime(nullable: false),
                        RegTime = c.DateTime(nullable: false),
                        QQ = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                        RId = c.Int(nullable: false),
                        IDCard = c.String(),
                        RealName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RId, cascadeDelete: true)
                .Index(t => t.RId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        RId = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RId, cascadeDelete: true)
                .Index(t => t.RId);
            
            CreateTable(
                "dbo.WebSite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Domain = c.String(nullable: false, maxLength: 50),
                        Tag = c.String(maxLength: 500),
                        CreateTime = c.DateTime(nullable: false),
                        UId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Module", new[] { "RId" });
            DropIndex("dbo.User", new[] { "RId" });
            DropIndex("dbo.Reply", new[] { "UId" });
            DropIndex("dbo.Reply", new[] { "CId" });
            DropIndex("dbo.Content", new[] { "CId" });
            DropIndex("dbo.Chanel", new[] { "UId" });
            DropIndex("dbo.Chanel", new[] { "WId" });
            DropForeignKey("dbo.Module", "RId", "dbo.Role");
            DropForeignKey("dbo.User", "RId", "dbo.Role");
            DropForeignKey("dbo.Reply", "UId", "dbo.User");
            DropForeignKey("dbo.Reply", "CId", "dbo.Content");
            DropForeignKey("dbo.Content", "CId", "dbo.Chanel");
            DropForeignKey("dbo.Chanel", "UId", "dbo.User");
            DropForeignKey("dbo.Chanel", "WId", "dbo.WebSite");
            DropTable("dbo.WebSite");
            DropTable("dbo.Module");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Reply");
            DropTable("dbo.Content");
            DropTable("dbo.Chanel");
        }
    }
}
