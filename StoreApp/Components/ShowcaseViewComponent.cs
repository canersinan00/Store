using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _meneger;

        public ShowcaseViewComponent(IServiceManager meneger)
        {
            _meneger = meneger;
        }

        public IViewComponentResult Invoke()
        {
            var products = _meneger.ProductService.GetShowcaseProducts(false);
            return View(products);
        }
    }
}