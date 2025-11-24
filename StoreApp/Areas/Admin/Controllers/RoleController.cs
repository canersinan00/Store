using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]

    public class RoleController : Controller
    {
        private readonly IServiceManager _meneger;

        public RoleController(IServiceManager meneger)
        {
            _meneger = meneger;
        }
        public IActionResult Index()
        {
            return View(_meneger.AuthService.Roles);
        }
    }
}