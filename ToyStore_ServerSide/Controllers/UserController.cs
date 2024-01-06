using BLL.Classes;
using Entities_DTO.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToyStore_ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(UsersBLL.GetAllUsers());
        }

        [HttpGet("GetUserByEmailAndPass/{email}/{pass}")]
        public IActionResult GetUserByEmailAndPass(string email, string pass) 
        {
            return Ok(UsersBLL.GetUserByEmailAndPassword(email, pass));
        }

        [HttpPut("AddUser")]
        public IActionResult AddUser([FromBody] UserDTO u)
        {
            return Ok(UsersBLL.AddUser(u));
        }

        [HttpPost("UpdateUser/{id}")]
        public IActionResult UpdateUser(string id, [FromBody] UserDTO u)
        {
            return Ok(UsersBLL.UpdateUser(id, u));
        }
    }
}
