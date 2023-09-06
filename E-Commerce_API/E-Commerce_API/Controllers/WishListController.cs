using E_Commerce_API.Request.Command;
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

    }
}
