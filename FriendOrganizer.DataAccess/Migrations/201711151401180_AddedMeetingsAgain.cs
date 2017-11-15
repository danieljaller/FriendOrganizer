namespace FriendOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMeetingsAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friend", "Meeting_Id", "dbo.Meeting");
            DropIndex("dbo.Friend", new[] { "Meeting_Id" });
            CreateTable(
                "dbo.MeetingFriend",
                c => new
                    {
                        Meeting_Id = c.Int(nullable: false),
                        Friend_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meeting_Id, t.Friend_Id })
                .ForeignKey("dbo.Meeting", t => t.Meeting_Id, cascadeDelete: true)
                .ForeignKey("dbo.Friend", t => t.Friend_Id, cascadeDelete: true)
                .Index(t => t.Meeting_Id)
                .Index(t => t.Friend_Id);
            
            DropColumn("dbo.Friend", "Meeting_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Friend", "Meeting_Id", c => c.Int());
            DropForeignKey("dbo.MeetingFriend", "Friend_Id", "dbo.Friend");
            DropForeignKey("dbo.MeetingFriend", "Meeting_Id", "dbo.Meeting");
            DropIndex("dbo.MeetingFriend", new[] { "Friend_Id" });
            DropIndex("dbo.MeetingFriend", new[] { "Meeting_Id" });
            DropTable("dbo.MeetingFriend");
            CreateIndex("dbo.Friend", "Meeting_Id");
            AddForeignKey("dbo.Friend", "Meeting_Id", "dbo.Meeting", "Id");
        }
    }
}
