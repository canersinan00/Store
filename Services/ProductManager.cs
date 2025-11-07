using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _maneger;

        public ProductManager(IRepositoryManager maneger)
        {
            _maneger = maneger;
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _maneger.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _maneger.Product.GetOneProduct(id, trackChanges);

            if (product is null)
            {
                throw new Exception("Prodcut not found!");
            }
            return product;
        }
    }
}