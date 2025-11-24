using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class UserController : Controller
    {
        private readonly IServiceManager _meneger;

        public UserController(IServiceManager meneger)
        {
            _meneger = meneger;
        }
        public IActionResult Index()
        {
            var users = _meneger.AuthService.GetAllUsers();
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

        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var user = await _meneger.AuthService.GetOneUserForUpdate(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
        {
            if (ModelState.IsValid)
            {
                await _meneger.AuthService.Update(userDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new ResetPasswordDto
            {
                UserName = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto model)
        {

            var result = await _meneger.AuthService.ResetPassword(model);

            return result.Succeeded
                ? RedirectToAction("Index")
                : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOneUser([FromForm] UserDto userDto)
        {
            var result = await _meneger
                .AuthService
                .DeletOneUser(userDto.UserName);

            return result.Succeeded
                ? RedirectToAction("Index")
                : View();

        }

    }
}