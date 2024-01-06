using BLL.Classes;
using Entities_DTO.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToyStore_ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailsController : ControllerBase
    {
        [HttpGet("GetAllSaleDetails")]
        public IActionResult GetAllSaleDetails()
        {
            return Ok(SaleDetailsBLL.GetAllSaleDetails());
        }

        [HttpPut("AddSalesDetails")]
        public IActionResult AddSalesDetails([FromBody] SaleDetailsDTO s)
        {
            return Ok(SaleDetailsBLL.AddSaleDetails(s));
        }
    }
}
