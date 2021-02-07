namespace ThyRealmBeyond.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ThyRealmBeyond.Data.Models;

    internal class BlogPostSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BlogPosts.Any())
            {
                return;
            }

            await dbContext.BlogPosts.AddAsync(new BlogPost
            {
                Title = "First Time Test Title",
                Content = "Emo DnD best DnD",
                UserId = "cd474f1f-5421-411e-a3a9-80d2b1f5f2ad",
                IsDeleted = false,
            });
        }
    }
}
