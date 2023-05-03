using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductInventryService.Model;
using ProductInventryService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInventryController : ControllerBase
    {
        private readonly IProductInventryRepository _productInventryRepository;
        public ProductInventryController(IProductInventryRepository productInventryRepository)
        {
            _productInventryRepository = productInventryRepository;
        }

        [HttpPost("addquantity")]
        [Authorize(Roles ="Admin")]
        public ActionResult<ProductInventryModel> AddQuantity(ProductInventryModel productInventryModel)
        {
            try
            {
                var product = _productInventryRepository.AddQuantity(productInventryModel);
                return Ok(product);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updatequantity")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ProductInventryModel> UpdateQuantity(ProductInventryModel productInventryModel)
        {
            try
            {
                var product = _productInventryRepository.UpdateQuantity(productInventryModel);
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getquantity/{id}")]
        [Authorize]
        public ActionResult<ProductInventryModel> GetQuantity(Guid id)
        {
            try
            {
                var product = _productInventryRepository.GetProductQuantity(id);
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getproductquantity")]
        [Authorize]
        public ActionResult<ProductInventryModel> GetProductQuantity()
        {
            try
            {
                var product = _productInventryRepository.GetAllProductQuantity();
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
