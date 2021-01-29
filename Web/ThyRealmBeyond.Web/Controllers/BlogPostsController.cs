namespace ThyRealmBeyond.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ThyRealmBeyond.Services.Data;
    using ThyRealmBeyond.Web.ViewModels.BlogPosts;

    public class BlogPostsController : Controller
    {
        private readonly IBlogPostService blogPostService;

        public BlogPostsController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public IActionResult ByTitle(string title)
        {
            var viewModel = this.blogPostService.GetByTiTle<BlogPostViewModel>(title);
            return this.View();
        }
    }
}
