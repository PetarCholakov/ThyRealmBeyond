namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using ThyRealmBeyond.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
