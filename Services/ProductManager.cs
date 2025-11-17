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
            return _maneger.Product.GetOneProduct(id, trackChanges);
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;

        }

        public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
        {
            var products = _maneger.Product.GetShowcaseProducts(trackChanges);
            return products;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            // var entity = _maneger.Product.GetOneProduct(productDto.ProductId, true);
            // entity.ProductName = productDto.ProductName;
            // entity.Price = productDto.Price;
            // entity.CategoryId = productDto.CategoryId;
            var entity = _mapper.Map<Product>(productDto);
            _maneger.Product.UpdateOneProduct(entity);
            _maneger.Save();
        }
    }
}