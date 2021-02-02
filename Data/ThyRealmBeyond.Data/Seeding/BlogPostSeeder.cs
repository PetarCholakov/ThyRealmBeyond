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
                UserId = "057368c9-e018-4813-b224-88db77bdf1b5",
            });
        }
    }
}
