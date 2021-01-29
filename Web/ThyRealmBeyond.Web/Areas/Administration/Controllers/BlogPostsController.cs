namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ThyRealmBeyond.Data;
    using ThyRealmBeyond.Data.Common.Repositories;
    using ThyRealmBeyond.Data.Models;

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
            return this.View(await this.context.BlogPosts.OrderBy(x => x.CreatedOn).Take(10).ToListAsync());
        }
    }
}
