namespace Blog2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(),
                        PostBody = c.String(),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.TagPost",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId })
                .ForeignKey("dbo.Tag", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Post_PostId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TagPost", new[] { "Post_PostId" });
            DropIndex("dbo.TagPost", new[] { "Tag_TagId" });
            DropForeignKey("dbo.TagPost", "Post_PostId", "dbo.Post");
            DropForeignKey("dbo.TagPost", "Tag_TagId", "dbo.Tag");
            DropTable("dbo.TagPost");
            DropTable("dbo.Tag");
            DropTable("dbo.Post");
        }
    }
}
