namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ThyRealmBeyond.Common;
    using ThyRealmBeyond.Data.Common.Repositories;
    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Data;
    using ThyRealmBeyond.Web.ViewModels.Administration.BlogPosts;

    [Area(GlobalConstants.AdministrationAreaName)]
    public class BlogPostsController : AdministrationController
    {
        private const int PostsPerPageDefaultValue = 10;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogPostService blogPostService;

        public BlogPostsController(UserManager<ApplicationUser> userManager, IBlogPostService blogPostService)
        {
            this.userManager = userManager;
            this.blogPostService = blogPostService;
        }

        // GET: Administration/BlogPosts
        public IActionResult Index(int page = 1)
        {
            var result = this.blogPostService
                .GetAll<BlogPostViewModel>();

            var count = result.Count();

            var viewModel = new IndexBlogPostViewModel
            {
                BlogPosts = result.Skip(PostsPerPageDefaultValue * (page - 1)).Take(PostsPerPageDefaultValue),
                PagesCount = (int)Math.Ceiling((double)count / PostsPerPageDefaultValue),
                CurrentPage = page,
            };

            return this.View(viewModel);
        }

        // GET: Administration/BlogPosts/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var viewModel = await this.blogPostService.GetByIdAsync<BlogPostViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        // GET: Administration/BlogPosts/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/BlogPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostCreateInputModel inputModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (this.ModelState.IsValid)
            {
                await this.blogPostService.CreateAsync(inputModel.Title, inputModel.Content, user.Id, inputModel.PreviewContent);
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(inputModel);
        }

        // GET: Administration/BlogPosts/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var viewModel = await this.blogPostService.GetByIdAsync<BlogPostEditInputModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        // POST: Administration/Blogposts/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogPostEditInputModel inputModel)
        {
            if (id != inputModel.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    await this.blogPostService.UpdateAsync(inputModel.Id, inputModel.Title, inputModel.Content, inputModel.PreviewContent);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (this.blogPostService.CheckBlogPostExist(id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/BlogPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var viewModel = await this.blogPostService.GetByIdAsync<BlogPostViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        // POST: Administration/BlogPosts/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await this.blogPostService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
