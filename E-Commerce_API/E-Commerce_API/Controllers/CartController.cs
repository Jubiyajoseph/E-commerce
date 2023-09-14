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

        [HttpDelete]
        public async Task<bool> DeleteCart(int cartId)
        {
            var command = new DeleteCartCommand { CartId = cartId };
            return await _mediator.Send(command);
        }

        [HttpGet("{userId}/cart-total-price")]
        public async Task<ActionResult<decimal>> GetUserCartTotal(int userId)
        {
            var query = new GetCartTotalPriceByUserIdQuery { UserId = userId };
            var total = await _mediator.Send(query);

            return Ok(total);
        }


        [HttpGet("GetCartItemsByUserId/{userId}")]
        public async Task<IActionResult> GetCartItemsByUserId(int userId)
        {
            var query = new GetCartQuantityByUserIdQuery { UserId = userId };
            var cartItems = await _mediator.Send(query);

            return Ok(cartItems);
        }


        [HttpPut("update-stock")]
        public async Task<bool> UpdateStock([FromBody] UpdateProductStockCommand command)
        {
            
                bool result = await _mediator.Send(command);

                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
        }
    }
}
