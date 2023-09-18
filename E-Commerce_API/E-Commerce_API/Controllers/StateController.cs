using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public StateController(ECommerceDbContext context)
        {
            _context = context;
        }
        // POST api/<StateController>
        [HttpPost]
        public IActionResult AddState([FromBody] State state)
        {
            _context.State.Add(state);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            var states = await _context.State.ToListAsync();
            return Ok(states);
        }
    }
}
