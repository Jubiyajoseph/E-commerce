using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Repository.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly E_Commerce_DbContext _context;

        public StateController(E_Commerce_DbContext context)
        {
            _context = context;
        }
        // POST api/<StateController>
        [HttpPost]
        public IActionResult AddCity([FromBody] State state)
        {
            _context.State.Add(state);
            _context.SaveChanges();
            return Ok();
        }
    }
}
