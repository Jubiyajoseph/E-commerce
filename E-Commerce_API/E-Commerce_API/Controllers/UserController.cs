
using E_Commerce_API.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;   

        public UserController(IMediator mediator)
        {
   
            _mediator = mediator;
        }

       
        [HttpPost]
        public async Task<ActionResult<bool>> AddUser([FromBody] AddUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login([FromBody] AddUserValidationCommand validationCommand)
        {
           return Ok(await _mediator.Send(validationCommand));
        }
    }
}
