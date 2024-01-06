using BLL.Classes;
using DAL.Models;
using Entities_DTO.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToyStore_ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        [HttpPost("Checkout/{user}")]
        public IActionResult Checkout(string user, [FromBody] List<CartDTO> cart)
        {
            return Ok(CartBLL.Checkout(user,cart));
        }
    }
}
