using System.Data.Entity.Migrations;

namespace ORM.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Description = c.String(),
                    CreatorId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId);

            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    DateOfBirth = c.DateTime(),
                    JoinDate = c.DateTime(nullable: false),
                    LastActivity = c.DateTime(nullable: false),
                    Location = c.String(),
                    IsOnline = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Post",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Description = c.String(),
                    CreatorId = c.Int(nullable: false),
                    TopicId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topic", t => t.TopicId)
                .ForeignKey("dbo.User", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId)
                .Index(t => t.TopicId);

            CreateTable(
                "dbo.Reply",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    WrittenTime = c.DateTime(nullable: false),
                    IsSubject = c.Boolean(nullable: false),
                    Content = c.String(nullable: false),
                    PostId = c.Int(nullable: false),
                    WriterId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId)
                .ForeignKey("dbo.User", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.WriterId);

            CreateTable(
                "dbo.Topic",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Description = c.String(),
                    CreatorId = c.Int(nullable: false),
                    CategoryId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.User", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Role",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UsersInRoles",
                c => new
                {
                    RoleId = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Category", "CreatorId", "dbo.User");
            DropForeignKey("dbo.UsersInRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Reply", "WriterId", "dbo.User");
            DropForeignKey("dbo.Post", "CreatorId", "dbo.User");
            DropForeignKey("dbo.Post", "TopicId", "dbo.Topic");
            DropForeignKey("dbo.Topic", "CreatorId", "dbo.User");
            DropForeignKey("dbo.Topic", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Reply", "PostId", "dbo.Post");
            DropIndex("dbo.UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.Topic", new[] { "CategoryId" });
            DropIndex("dbo.Topic", new[] { "CreatorId" });
            DropIndex("dbo.Reply", new[] { "WriterId" });
            DropIndex("dbo.Reply", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "TopicId" });
            DropIndex("dbo.Post", new[] { "CreatorId" });
            DropIndex("dbo.Category", new[] { "CreatorId" });
            DropTable("dbo.UsersInRoles");
            DropTable("dbo.Role");
            DropTable("dbo.Topic");
            DropTable("dbo.Reply");
            DropTable("dbo.Post");
            DropTable("dbo.User");
            DropTable("dbo.Category");
        }
    }
}