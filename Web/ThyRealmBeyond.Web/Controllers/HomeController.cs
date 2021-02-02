namespace ThyRealmBeyond.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using ThyRealmBeyond.Services.Data;
    using ThyRealmBeyond.Web.ViewModels;
    using ThyRealmBeyond.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IBlogPostService blogPostService;

        public HomeController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                BlogPosts =
                    this.blogPostService.GetAll<IndexBlogPostViewModel>(5),
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
