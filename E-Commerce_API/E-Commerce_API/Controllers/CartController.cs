using E_Commerce_API.Request.Command;
using E_Commerce_API.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<bool>> AddCart([FromBody] AddCartCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartDetailsQuery>> GetCart(int userId)
        {
            var query = new GetUserIDQuery { UserId = userId };
            var cart = await _mediator.Send(query);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
    }
}
