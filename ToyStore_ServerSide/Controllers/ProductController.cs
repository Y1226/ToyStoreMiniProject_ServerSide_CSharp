using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Classes;
using Entities_DTO.Repository;

namespace ToyStore_ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("GetAllProductsInStore")]
        public IActionResult GetAllProductsInStore()
        {
            return Ok(ProductBLL.GetAllProducts());
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(ProductBLL.GetProductByID(id));
        }

        [HttpGet("GetProductByCategoryId/{id}")]
        public IActionResult GetProductByCategoryId(int id)
        {
            return Ok(ProductBLL.GetProductByCategoryId(id));
        }

        [HttpPut("AddProduct")]
        public IActionResult AddProduct([FromBody] ProductDTO p)
        {
            return Ok(ProductBLL.AddProduct(p));
        }

        [HttpDelete("DeleteByProdID/{id}")]
        public IActionResult DeleteByProdID(int id)
        {
            return Ok(ProductBLL.DeleteProductById(id));
        }

        [HttpPost("UpdateProductById/{id}")]
        public IActionResult UpdateProductById(int id, [FromBody] ProductDTO p)
        {
            return Ok(ProductBLL.UpdateProduct(id, p));
        }
    }
}
