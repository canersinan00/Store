using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _maneger;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager maneger, IMapper mapper)
        {
            _maneger = maneger;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _maneger.Product.Create(product);
            _maneger.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id, false);
            if (product is not null)
            {
                _maneger.Product.DeleteOneProduct(product);
                _maneger.Save();
            }
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

        public void UpdateOneProduct(Product product)
        {
            var entity = _maneger.Product.GetOneProduct(product.ProductId, true);
            entity.ProductName = product.ProductName;
            entity.Price = product.Price;
            _maneger.Save();
        }
    }
}