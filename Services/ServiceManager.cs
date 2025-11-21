using System;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderServices _orderService;
        private readonly IAuthService _authService;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderServices orderService, IAuthService authService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _authService = authService;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderServices OrderService => _orderService;

        public IAuthService AuthService => _authService;
    }
}