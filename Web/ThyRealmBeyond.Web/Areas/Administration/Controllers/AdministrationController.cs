namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ThyRealmBeyond.Common;
    using ThyRealmBeyond.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area(GlobalConstants.AdministrationAreaName)]
    public class AdministrationController : BaseController
    {
    }
}
