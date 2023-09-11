using E_Commerce.Model.Models.AddressModel;
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


        [HttpGet]
        public async Task<ActionResult<List<AddressDetailsQuery>>> GetAddressesByUserId(int userId)
        {
            var query = new GetAddressByUserIdQuery { UserId = userId };
            var addresses = await _mediator.Send(query);

            if (addresses == null)
            {
                return NotFound(); 
            }

            return Ok(addresses);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateAddress(int id, [FromBody] UpdateAddressCommand command)
        {            
            // Set the ID from the route parameter
            command.AddressId = id;

            var result = await _mediator.Send(command);

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
