using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _meneger;
        private readonly Cart _cart;

        public OrderController(IServiceManager meneger, Cart cart)
        {
            _meneger = meneger;
            _cart = cart;
        }
        [Authorize]
        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart empty.");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _meneger.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complate", new { OrderId = order.OrderId });
            }
            else
            {
                return View();
            }
        }
    }
}