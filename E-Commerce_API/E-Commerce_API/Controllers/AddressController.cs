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

        //[HttpGet]
        //public async Task<ActionResult<Address>> GetAddressDetailsByUserId(int userId)
        //{
        //    var query = new GetAddressByUserIdQuery { UserId = userId };
        //    var address = await _mediator.Send(query);

        //    if (address == null)
        //    {
        //        return NotFound(); // Return a 404 response if the address is not found for the given user.
        //    }

        //    return Ok(address);
        //}

        [HttpGet]
        public async Task<ActionResult<List<AddressDetailsQuery>>> GetAddressesByUserId(int userId)
        {
            var query = new GetAddressByUserIdQuery { UserId = userId };
            var addresses = await _mediator.Send(query);

            if (addresses == null /*|| addresses.Count == 0*/)
            {
                return NotFound(); 
            }

            return Ok(addresses);
        }


    }
}
