namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ThyRealmBeyond.Common;
    using ThyRealmBeyond.Services.Data;
    using ThyRealmBeyond.Web.ViewModels.Administration.PersonalInfo;
    using ThyRealmBeyond.Web.ViewModels.PersonalInfo;

    [Area(GlobalConstants.AdministrationAreaName)]
    public class PersonalInfoController : AdministrationController
    {
        private readonly IPersonalInfoService personalInfoService;

        public PersonalInfoController(IPersonalInfoService personalInfoService)
        {
            this.personalInfoService = personalInfoService;
        }

        // GET: Administration/PersonalInfo/
        public IActionResult Index()
        {
            if (this.personalInfoService.GetPersonalInfo<PersonalInfoViewModel>() == null)
            {
                return this.RedirectToAction(nameof(this.Create));
            }

            var viewModel = this.personalInfoService.GetPersonalInfo<PersonalInfoViewModel>();

            return this.View(viewModel);
        }

        // GET: Administration/PersonalInfo/Create
        public IActionResult Create()
        {
            if (this.personalInfoService.GetPersonalInfo<PersonalInfoViewModel>() != null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View();
        }

        // POST: Administration/PersonalInfo/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(PersonalInfoCreateInputModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                await this.personalInfoService.CreateAsync(inputModel.Title, inputModel.Content, inputModel.ImageUrl, inputModel.Email);

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(inputModel);
        }

        public IActionResult Edit()
        {
            var inputModel = this.personalInfoService.GetPersonalInfo<PersonalInfoEditInputModel>();

            return this.View(inputModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(PersonalInfoEditInputModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await this.personalInfoService.EditAsync(inputModel.Title, inputModel.Content, inputModel.ImageUrl, inputModel.Email);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (this.personalInfoService.PersonalInfoExists())
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
    }
}
