using Entities.Dtos;
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
        public IActionResult Create()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_meneger
                .AuthService
                .Roles
                .Select(r => r.Name!)
                .Where(n => n != null)
                .ToList())
            });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            var result = await _meneger.AuthService.CreateUser(userDto);
            return result.Succeeded
                ? RedirectToAction("Index")
                : View(userDto);

        }
        
        public async Task<IActionResult> Update([FromRoute(Name ="id")]string id)
        {
            var user = await 
        }
        

    }
}