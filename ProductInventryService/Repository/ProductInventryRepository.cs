using ProductInventryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventryService.Repository
{
    public class ProductInventryRepository : IProductInventryRepository
    {
        private readonly List<ProductInventryModel> _productInventryModels;

        public ProductInventryRepository()
        {
            _productInventryModels = new List<ProductInventryModel>();
        }
        public ProductInventryModel AddQuantity(ProductInventryModel productInventryModel)
        {
          
            var product = new ProductInventryModel
            {
                Id = productInventryModel.Id,
                Quantity = productInventryModel.Quantity
            };
            _productInventryModels.Add(product);
            return product;
        }
        public ProductInventryModel GetProductQuantity(Guid id)
        {
            return _productInventryModels.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<ProductInventryModel> GetAllProductQuantity()
        {
            return _productInventryModels.ToList();
        }
        public Guid UpdateQuantity(ProductInventryModel productInventryModel)
        {
            var product = _productInventryModels.FirstOrDefault(x => x.Id == productInventryModel.Id);

            if(product == null)
            {
                throw new ArgumentException("Product not found");
            }

            var updatedQuantity = _productInventryModels.Select(x =>
            {
                if (x.Id == productInventryModel.Id)
                {
                    x.Quantity = product.Quantity;
                }
                return x;
            });

            return productInventryModel.Id;
        }
    }
}
