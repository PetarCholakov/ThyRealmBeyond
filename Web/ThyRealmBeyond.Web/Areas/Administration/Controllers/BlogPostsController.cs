namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ThyRealmBeyond.Data;
    using ThyRealmBeyond.Data.Common.Repositories;
    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Data;
    using ThyRealmBeyond.Web.ViewModels.BlogPosts;

    [Area("Administration")]
    public class BlogPostsController : AdministrationController
    {
        private readonly IRepository<BlogPost> repository;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IBlogPostService blogPostService;

        public BlogPostsController(IRepository<BlogPost> repository, UserManager<ApplicationUser> userManager, IBlogPostService blogPostService)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.blogPostService = blogPostService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.repository
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(10)
                .ToListAsync();
            return this.View(result);
        }

        public IActionResult ById(int id)
        {
            var blogPostViewModel = this.blogPostService
                .GetById<BlogPostViewModel>(id);

            if (blogPostViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(blogPostViewModel);
        }

        public IActionResult Create() => this.View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostCreateInputModel inputModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var blogPostId = await this.blogPostService.CreateAsync(inputModel.Title, inputModel.Content, user.Id);

            this.TempData["InfoMessage"] = "Blog post successfully created!";

            return this.RedirectToAction(nameof(this.ById), new { id = blogPostId });
        }
    }
}
