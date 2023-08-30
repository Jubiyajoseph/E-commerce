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
        private readonly UserAuthentication _userAuthentication;

        public UserController(E_Commerce_DbContext context,UserAuthentication userAuthentication)
        {
            _context = context;
            _userAuthentication = userAuthentication;
        }
        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserController>
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
                return Ok("Login successful!");
            }

            return Unauthorized("Invalid credentials.");
           
        }
        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
