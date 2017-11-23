namespace FriendOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuotesWithNullableForeignKeyInFriends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Category = c.String(),
                        QuoteText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Friend", "QuoteId", c => c.Int());
            CreateIndex("dbo.Friend", "QuoteId");
            AddForeignKey("dbo.Friend", "QuoteId", "dbo.Quote", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friend", "QuoteId", "dbo.Quote");
            DropIndex("dbo.Friend", new[] { "QuoteId" });
            DropColumn("dbo.Friend", "QuoteId");
            DropTable("dbo.Quote");
        }
    }
}
