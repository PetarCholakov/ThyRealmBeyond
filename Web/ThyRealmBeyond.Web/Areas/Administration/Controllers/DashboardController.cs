namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ThyRealmBeyond.Services.Data;

    public class DashboardController : AdministrationController
    {
        private readonly IBlogPostService blogPostService;

        public DashboardController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
