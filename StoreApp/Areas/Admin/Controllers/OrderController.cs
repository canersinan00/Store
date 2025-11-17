using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _meneger;

        public OrderController(IServiceManager meneger)
        {
            _meneger = meneger;
        }
        public IActionResult Index()
        {
            var orders = _meneger.OrderService.Orders;
            return View(orders);
        }

        [HttpPost]
        public IActionResult Complate([FromForm] int id)
        {
            _meneger.OrderService.Complate(id);
            return RedirectToAction("Index");
        }
    }
}