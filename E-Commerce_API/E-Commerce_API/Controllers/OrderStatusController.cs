using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ECommerceDbContext _context;
        public OrderStatusController(IMediator mediator,ECommerceDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<bool>> AddOrderStatus([FromBody] AddOrderStatusCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetStatusById(int statusId)
        {
            var status = await _context.OrderStatus
                        .Where(o => o.OrderStatusId == statusId)
                        .Select(o=>o.Status)
                        .FirstOrDefaultAsync();
            if(status != null)
            {
                return Ok(status);
            }
            return NotFound();
        }

    }
}
