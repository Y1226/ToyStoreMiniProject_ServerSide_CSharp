using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Entities_DTO.Mapping;
using Entities_DTO.Repository;
using DAL.Models;
using DAL.Actions;
using BLL.Classes;

namespace ToyStore_ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("GetAllCategorys")]
        public IActionResult GetAllCategorys()
        {
            return Ok(CategoryBLL.GetAllCategorys());
        }

        [HttpPut("AddCategory")]
        public IActionResult AddCategory([FromBody] CategoryDTO c)
        {
            return Ok(CategoryBLL.AddCategory(c));
        }

        [HttpDelete("DeleteByCategoryID/{id}")]
        public IActionResult DeleteByCategoryID(int id)
        {
            return Ok(CategoryBLL.DeleteCategoryById(id));
        }

        [HttpPost("UpdateCategoryById/{id}")]
        public IActionResult UpdateCategoryById(int id, [FromBody] CategoryDTO c)
        {
            return Ok(CategoryBLL.UpdateCategory(id, c));
        }
    }
}
