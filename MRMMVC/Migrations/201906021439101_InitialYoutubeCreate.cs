namespace MRMMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialYoutubeCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YouTubeDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ThumbnailImage = c.String(),
                        VideoId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.YouTubeDetail");
        }
    }
}
