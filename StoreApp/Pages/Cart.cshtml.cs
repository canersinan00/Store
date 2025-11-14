using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructe.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        public Cart Cart { get; set; }  //IoC
        public string ReturnUrl { get; set; } = "/";
        public CartModel(IServiceManager maneger, Cart cartService)
        {
            _manager = maneger;
            Cart = cartService;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnId)
        {
            var product = _manager.ProductService.GetOneProduct(productId, false);

            if (product is not null)
            {
                // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                // HttpContext.Session.SetJson<Cart>("cart", Cart);
            }

            return Page();
        }


        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            var line = Cart.Lines.FirstOrDefault(cl => cl.Product.ProductId == id);
            Cart.RemoveLine(line.Product);
            // HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }

    }
}