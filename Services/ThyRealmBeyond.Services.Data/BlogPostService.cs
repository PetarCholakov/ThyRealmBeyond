namespace ThyRealmBeyond.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<BlogPost> query =
                this.blogPostRepository.All().OrderBy(x => x.CreatedOn);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

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
    }
}
