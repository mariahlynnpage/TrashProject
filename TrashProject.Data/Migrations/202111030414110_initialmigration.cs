namespace TrashProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compactor",
                c => new
                    {
                        CompactorId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CompactorName = c.String(),
                        IsTrash = c.Boolean(nullable: false),
                        IsContaminated = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDryWaste = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompactorId);
            
            CreateTable(
                "dbo.HaulerInfo",
                c => new
                    {
                        HaulerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        HaulerName = c.String(),
                        HaulerPhoneNumber = c.String(),
                        HaulerEmail = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.HaulerId);
            
            CreateTable(
                "dbo.Haul",
                c => new
                    {
                        HaulId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CompactorId = c.Int(nullable: false),
                        HaulerInfoId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        PropertyContactId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.HaulId)
                .ForeignKey("dbo.Compactor", t => t.CompactorId, cascadeDelete: true)
                .ForeignKey("dbo.HaulerInfo", t => t.HaulerInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyContact", t => t.PropertyContactId, cascadeDelete: true)
                .Index(t => t.CompactorId)
                .Index(t => t.HaulerInfoId)
                .Index(t => t.PropertyId)
                .Index(t => t.PropertyContactId);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        PropertyId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PropertyName = c.String(),
                        Address = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.PropertyId);
            
            CreateTable(
                "dbo.PropertyContact",
                c => new
                    {
                        PropertyContactId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PropContactPosition = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PropContactPhoneNumber = c.String(),
                        PropContactEmail = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.PropertyContactId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Haul", "PropertyContactId", "dbo.PropertyContact");
            DropForeignKey("dbo.Haul", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Haul", "HaulerInfoId", "dbo.HaulerInfo");
            DropForeignKey("dbo.Haul", "CompactorId", "dbo.Compactor");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Haul", new[] { "PropertyContactId" });
            DropIndex("dbo.Haul", new[] { "PropertyId" });
            DropIndex("dbo.Haul", new[] { "HaulerInfoId" });
            DropIndex("dbo.Haul", new[] { "CompactorId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PropertyContact");
            DropTable("dbo.Property");
            DropTable("dbo.Haul");
            DropTable("dbo.HaulerInfo");
            DropTable("dbo.Compactor");
        }
    }
}
