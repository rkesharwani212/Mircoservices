using ProductInventryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventryService.Repository
{
    public interface IProductInventryRepository
    {
        ProductInventryModel GetProductQuantity(Guid id);
        ProductInventryModel AddQuantity(ProductInventryModel productInventryModel);
        IEnumerable<ProductInventryModel> GetAllProductQuantity();
        Guid UpdateQuantity(ProductInventryModel productInventryModel);



    }
}
