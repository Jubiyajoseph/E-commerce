using E_Commerce.Model.Models.ProductsModel;
using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Command;
using E_Commerce_API.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private E_Commerce_DbContext _context;
        public ProductController(E_Commerce_DbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddProduct([FromBody] AddProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<AddProductCommand>> GetProduct(int productId)
        {
            var query = new GetProductQuery { ProductID = productId };
            var product = await _mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        { 
            return Ok(_context.Product); 
        }


        [HttpGet("search")]
        public ActionResult<IEnumerable<Product>> SearchProducts(string searchTerm)
        {
            var query = _context.Product
                .Where(p =>
                    p.Name.Contains(searchTerm) ||
                    (p.Category.Name != null && p.Category.Name.Contains(searchTerm)) ||
                    (p.Brand.Name != null && p.Brand.Name.Contains(searchTerm))
                )
                .ToList();

            return Ok(query);
        }

        }
}
