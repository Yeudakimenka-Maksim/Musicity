using System.Data.Entity.Migrations;

namespace ORM.Migrations
{
    public partial class AddedCreationTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Post", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Topic", "CreationTime", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Topic", "CreationTime");
            DropColumn("dbo.Post", "CreationTime");
            DropColumn("dbo.Category", "CreationTime");
        }
    }
}