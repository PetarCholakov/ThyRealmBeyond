namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ThyRealmBeyond.Services.Data;

    public class DashboardController : AdministrationController
    {
        public DashboardController(IBlogPostService blogPostService)
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
