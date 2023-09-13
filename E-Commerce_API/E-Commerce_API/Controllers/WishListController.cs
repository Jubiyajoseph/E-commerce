using E_Commerce_API.Request.Command;
using E_Commerce_API.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : Controller
    {
        private readonly IMediator _mediator;
        
        public WishListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddWishlist([FromBody] AddWishListCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]

        public async Task<ActionResult<WishListDetailsQuery>> GetWishList(int userId)
        {
            var query = new GetWishListQuery { UserId = userId };
            var product = await _mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut]

        public async Task<bool> UpdateWishlist([FromBody] UpdateWishlistCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpDelete]
        public async Task<bool> DeleteWishList(int wishListId)
        {
            var command = new DeleteWishListCommand { WishListId = wishListId };
            return await _mediator.Send(command);
        }
    }
}
