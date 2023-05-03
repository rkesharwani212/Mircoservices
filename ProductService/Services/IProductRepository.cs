using ProductService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProduct();
        ProductModel GetProductById(Guid id);
        ProductModel AddProduct(ProductModel productModel);
        Guid DeleteProduct(Guid id);
        ProductModel UpdateProduct(ProductModel productModel);

    }
}
