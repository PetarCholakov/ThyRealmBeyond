namespace ThyRealmBeyond.Web.Areas.Administration.Controllers
{
    using ThyRealmBeyond.Common;
    using ThyRealmBeyond.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
