using ProductService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<ProductModel> _products;
        public ProductRepository()
        {
            _products = new List<ProductModel>() 
            {
                new ProductModel { Id = Guid.NewGuid(), Design = "my design1", Name = "product1", Price = 121, Size = 41},
                new ProductModel { Id = Guid.NewGuid(), Design = "my design2", Name = "product2", Price = 122, Size = 42},
                new ProductModel { Id = Guid.NewGuid(), Design = "my design3", Name = "product3", Price = 123, Size = 43},
            };
        }

        public IEnumerable<ProductModel> GetAllProduct()
        {
           return _products.ToList();
        }
        public ProductModel GetProductById(Guid id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }
        public ProductModel AddProduct(ProductModel productModel)
        {
            if (productModel == null)
            {
                throw new ArgumentNullException(nameof(productModel));
            }

            var product = new ProductModel
            {
                Id = Guid.NewGuid(),
                Name = productModel.Name,
                Size = productModel.Size,
                Price = productModel.Price,
                Design = productModel.Design
            };
            _products.Add(product);
            return product;
        }
        public Guid DeleteProduct(Guid id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return id;
        }
        public ProductModel UpdateProduct(ProductModel productModel)
        {
            if (productModel == null)
            {
                throw new ArgumentException("Product not found");
            }
            var updatedProduct = _products.Select(x =>
            {
                if (x.Id == productModel.Id)
                {
                    x.Name = productModel.Name;
                    x.Size = productModel.Size;
                    x.Price = productModel.Price;
                    x.Design = productModel.Design;
                }
                return x;
            });

            return productModel;
            
        }
    }
}
