using E_Commerce_API.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<bool>> AddOrder([FromBody] AddOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("place-order")]
         
        public async Task<bool> PlaceOrder([FromBody] AddPlaceOrderCommand command)
        {
            return (await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<bool> UpdateStatus([FromBody] UpdateStatusCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
            {
                return true;
            }
            return false;
        }

        [HttpPut("stock-update-on-cancel-order")]

        public async Task<bool> CancelOrder([FromBody] CancelOrderCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
            {
                return true;
            }
            return false;
        }
       
    }
}
