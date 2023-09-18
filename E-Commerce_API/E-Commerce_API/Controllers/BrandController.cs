using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Model.Models.ProductsModel;
using E_Commerce.Repository.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly ECommerceDbContext _context;
        public BrandController(ECommerceDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public IActionResult AddBrand([FromBody] Brand brand)
        {
            _context.Brand.Add(brand);
            _context.SaveChanges();
            return Ok();
        }
    }
}
