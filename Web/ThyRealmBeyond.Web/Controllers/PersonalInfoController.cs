namespace ThyRealmBeyond.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ThyRealmBeyond.Services.Data;
    using ThyRealmBeyond.Web.ViewModels.PersonalInfo;

    public class PersonalInfoController : BaseController
    {
        private readonly IPersonalInfoService personalInfoService;

        public PersonalInfoController(IPersonalInfoService personalInfoService)
        {
            this.personalInfoService = personalInfoService;
        }

        public IActionResult AboutMe()
        {
           var aboutMePost = this.personalInfoService.GetPersonalInfo<PersonalInfoViewModel>();

           return this.View(aboutMePost);
        }
    }
}
