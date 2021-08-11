namespace ASP.NET_Core_Project_Online_Shop.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Administration.AdminConstants;

    [Authorize(Roles = AdministratorRoleName)]
    [Area("Administration")]
    public class AdminController : Controller
    {
    }
}
