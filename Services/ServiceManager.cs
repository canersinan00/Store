using System;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderServices _orderService;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderServices orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderServices OrderService => _orderService;
    }
}