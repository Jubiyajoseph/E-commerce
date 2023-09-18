using E_Commerce.Model.Models.ProductsModel;
using E_Commerce.Repository.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ECommerceDbContext _context;
        public CategoryController(ECommerceDbContext context)
        {
            _context = context;

        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return Ok();
        }

        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
