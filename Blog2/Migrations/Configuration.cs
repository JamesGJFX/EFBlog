namespace Blog2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Blog2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog2.DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog2.DAL.BlogContext context)
        {
            var posts = new List<Post>
            {
                new Post { PostBody = "This is a test post, don't worry.", PostDate = DateTime.Now, PostTitle = "Test 1"},
                new Post { PostBody = "This is a test post, don't worry.", PostDate = DateTime.Now, PostTitle = "Test 2"},
                new Post { PostBody = "This is a test post, don't worry.", PostDate = DateTime.Now, PostTitle = "Test 3"},
                new Post { PostBody = "This is a test post, don't worry.", PostDate = DateTime.Now, PostTitle = "Test 4"}
            };
            posts.ForEach(s => context.Posts.AddOrUpdate(p => p.PostTitle, s));
            context.SaveChanges();

            var tags = new List<Tag>
            {
                new Tag { TagName = "Generic"},
                new Tag { TagName = "Specific"},
                new Tag { TagName = "Vague"}
            };

            tags.ForEach(s => context.Tags.AddOrUpdate(p => p.TagName, s));
            context.SaveChanges();
        }
    }
}
