using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;
using ProductService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetProduct")]
        [Authorize]
        public ActionResult<ProductModel> GetProduct()
        {
            try
            {
                var product = _productRepository.GetAllProduct();
                return Ok(product);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetProduct/{id}")]
        [Authorize]
        public ActionResult<ProductModel> GetProduct(Guid id)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("AddProduct")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ProductModel> AddProduct(ProductModel productModel)
        {
            try
            {
                var product = _productRepository.AddProduct(productModel);
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("UpdateProduct")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ProductModel> UpdateProduct(ProductModel productModel)
        {
            try
            {
                var product = _productRepository.UpdateProduct(productModel);
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("DeleteProduct/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ProductModel> DeleteProduct(Guid id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return Ok(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
