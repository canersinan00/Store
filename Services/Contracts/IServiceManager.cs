using Entities.Models;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService{ get; }
        IOrderServices OrderService { get; }
        IAuthService AuthService { get; }
    }
}