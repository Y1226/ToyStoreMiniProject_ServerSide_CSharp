using BLL.Classes;
using Entities_DTO.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToyStore_ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        [HttpGet("GetAllSales")]
        public IActionResult GetAllSales()
        {
            return Ok(SalesBLL.GetAllSales());
        }

        [HttpPut("AddSale")]
        public IActionResult AddSale([FromBody] SalesDTO s)
        {
            return Ok(SalesBLL.AddSale(s));
        }
    }
}
