using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _meneger;

        public UserController(IServiceManager meneger)
        {
            _meneger = meneger;
        }
        public IActionResult Index()
        {
            var users = _meneger.AuthService.GetAllUSers();
            return View(users);
        }
    }
}