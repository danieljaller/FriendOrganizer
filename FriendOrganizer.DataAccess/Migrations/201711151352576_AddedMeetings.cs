namespace FriendOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMeetings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meeting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Friend", "Meeting_Id", c => c.Int());
            CreateIndex("dbo.Friend", "Meeting_Id");
            AddForeignKey("dbo.Friend", "Meeting_Id", "dbo.Meeting", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friend", "Meeting_Id", "dbo.Meeting");
            DropIndex("dbo.Friend", new[] { "Meeting_Id" });
            DropColumn("dbo.Friend", "Meeting_Id");
            DropTable("dbo.Meeting");
        }
    }
}
