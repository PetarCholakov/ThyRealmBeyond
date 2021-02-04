namespace ThyRealmBeyond.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using ThyRealmBeyond.Data.Common.Repositories;
    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class BlogPostService : IBlogPostService
    {
        private readonly IRepository<BlogPost> blogPostRepository;

        public BlogPostService(IRepository<BlogPost> blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task<int> CreateAsync(string title, string content, string userId)
        {
            var blogPost = new BlogPost
            {
                Title = title,
                Content = content,
                UserId = userId,
            };

            await this.blogPostRepository.AddAsync(blogPost);
            await this.blogPostRepository.SaveChangesAsync();

            return blogPost.Id;
        }

        public async Task<int> UpdateAsync(int id, string title, string content)
        {
            var modelToUpdate = await this.blogPostRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            modelToUpdate.Title = title;
            modelToUpdate.Content = content;

            this.blogPostRepository.Update(modelToUpdate);
            await this.blogPostRepository.SaveChangesAsync();

            return modelToUpdate.Id;
        }

        public async Task<T> GetByIdAsync<T>(int? id)
        {
            var blogPost = await this.blogPostRepository
                .All()
                .Where(bp => bp.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return blogPost;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<BlogPost> query =
                this.blogPostRepository.All().OrderByDescending(x => x.CreatedOn);
            return query.To<T>().ToList();
        }

        public T GetByTitle<T>(string title)
        {
            var blogPost = this.blogPostRepository
                .All()
                .Where(bp => bp.Title.Replace(" ", "-") == title.Replace(" ", "-"))
                .To<T>()
                .FirstOrDefault();

            return blogPost;
        }

        public bool CheckBlogPostExist(int id)
        {
            return this.blogPostRepository.All().Any(x => x.Id == id);
        }
    }
}
