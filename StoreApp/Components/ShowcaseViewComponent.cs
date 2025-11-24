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

        public IViewComponentResult Invoke(string page = "default")
        {
            var products = _meneger.ProductService.GetShowcaseProducts(false);
            return page.Equals("default")
                ? View(products)
                : View("List", products);
        }
    }
}