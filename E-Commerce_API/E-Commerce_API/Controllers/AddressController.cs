using E_Commerce_API.Request.Command;
using E_Commerce_API.Request.Query;
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


        [HttpGet]
        public async Task<ActionResult<List<AddressDetailsQuery>>> GetAddressesByUserId(int userId)
        {
            var query = new GetAddressByUserIdQuery { UserId = userId };
            var addresses = await _mediator.Send(query);

            if (addresses == null)
            {
                return Ok(null); 
            }

            return Ok(addresses);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateAddress(int id, [FromBody] UpdateAddressCommand command)
        {            
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

        [HttpPut("update-isdeleted")]
        public async Task<bool> UpdateAddressIsDeleted([FromBody] UpdateIsDeletedCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("default/{userId}")]
        public async Task<ActionResult<AddressDetailsQuery>> GetUserDefaultAddress(int userId)
        {
            var query = new GetUserDefaultAddressQuery { UserId = userId };
            var addressInfo = await _mediator.Send(query);

            if (addressInfo == null)
            {
                return Ok(null); 
            }

            return Ok(addressInfo);
        }

        [HttpPut("update-default-address")]
        public async Task<bool> UpdateDefaultAddress(UpdateIsDefaultCommand command)
        {
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
