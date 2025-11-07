using Entities.Models;

namespace Services.Contracts
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
    }
}