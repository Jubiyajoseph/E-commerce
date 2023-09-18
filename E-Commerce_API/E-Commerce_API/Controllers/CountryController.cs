using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public CountryController(ECommerceDbContext context)
        {
            _context = context;
        }

        // POST api/<CountryController>
        [HttpPost]
        public IActionResult AddCountry([FromBody] Country country)
        {
            _context.Country.Add(country);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var country = await _context.Country.ToListAsync();
            return Ok(country);
        }


    }
}
