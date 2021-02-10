namespace ThyRealmBeyond.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    using ThyRealmBeyond.Services.Data;
    using ThyRealmBeyond.Web.ViewModels;
    using ThyRealmBeyond.Web.ViewModels.BlogPosts;
    using ThyRealmBeyond.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private const bool ShouldIncludeDeletedBlogPosts = false;
        private const int BlogPostsPerPageDefault = 5;
        private readonly IBlogPostService blogPostService;

        public HomeController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public IActionResult Index(int page = 1)
        {
            var result = this.blogPostService
                .GetAll<IndexBlogPostViewModel>(ShouldIncludeDeletedBlogPosts);

            var count = result.Count();
            var pagesCount = (int)Math.Ceiling((double)count / BlogPostsPerPageDefault);

            var viewModel = new IndexViewModel()
            {
                BlogPosts = result.Skip(BlogPostsPerPageDefault * (page - 1)).Take(BlogPostsPerPageDefault),
                PagesCount = pagesCount,
                CurrentPage = page,
            };


            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
