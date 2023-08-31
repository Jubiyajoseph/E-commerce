using E_Commerce.Model.Models.User;
using E_Commerce.Repository.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly E_Commerce_DbContext _context;
        private readonly UserAuthenticationHandler _userAuthentication;

        public UserController(E_Commerce_DbContext context,UserAuthenticationHandler userAuthentication)
        {
            _context = context;
            _userAuthentication = userAuthentication;
        }

       
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            return Ok("successfully Added");

        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserValidation userValidation)
        {
            User user = new User();
            user.Name = userValidation.Name;
            user.Password = userValidation.Password;
            if (_userAuthentication.ValidateCredentials(user.Name, user.Password))
            {
                var result = new LoginResult { Message = "Login successful!" };
                return Ok(result);
            }
            else
            {
                var result = new LoginResult { Message = "Invalid credentials." };
                return Unauthorized(result);
            }           
           
        }
    }
}
