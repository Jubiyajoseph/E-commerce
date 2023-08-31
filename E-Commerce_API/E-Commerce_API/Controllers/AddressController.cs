using E_Commerce_API.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<CountryController>
        [HttpPost]
        public  async Task<ActionResult<bool>> AddAddress([FromBody] AddAddressCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


    }
}
