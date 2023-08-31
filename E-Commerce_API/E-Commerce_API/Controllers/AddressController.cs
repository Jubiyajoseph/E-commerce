using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Model.Models.UserModel;
using E_Commerce.Repository.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly E_Commerce_DbContext _context;

        public AddressController(E_Commerce_DbContext context)
        {
            _context = context;
        }

        // POST api/<CountryController>
        [HttpPost]
        public IActionResult AddCity([FromBody] AddressHandler addressHandler)
        {
            Address address = new Address();
            address.ResidentialAddress=addressHandler.ResidentialAddress;   
            address.CityId=addressHandler.CityId;
            address.StateId=addressHandler.StateId;
            address.CountryId=addressHandler.CountryId;
            address.UserId=addressHandler.UserId;
            address.IsDeleted=addressHandler.IsDeleted; 
            _context.Address.Add(address);
            _context.SaveChanges();

            var result = new Result { Message = "success" };
           
            return Ok(result);
        }


    }
}
