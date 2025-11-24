using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategorySummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _meneger;

        public CategorySummaryViewComponent(IServiceManager meneger)
        {
            _meneger = meneger;
        }
        public string Invoke()
        {
            return _meneger
                .CategoryService
                .GetAllCategories(false)
                .Count()
                .ToString();
        }
    }
}