namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ThyRealmBeyond.Common;
    using ThyRealmBeyond.Data;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class BlogPostsController : Controller
    {
        private readonly ApplicationDbContext context;

        public BlogPostsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.BlogPosts
                .OrderByDescending(x => x.CreatedOn)
                .Take(10)
                .ToListAsync());
        }
    }
}
