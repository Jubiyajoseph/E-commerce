using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly E_Commerce_DbContext _context;
        public CityController(E_Commerce_DbContext context)
        {
            _context = context;

        }

        // POST api/<CityController>
        [HttpPost]
        public IActionResult AddCity([FromBody] City city)
        {
            _context.City.Add(city);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _context.City.ToListAsync();
            return Ok(cities);
        }

    }
}
