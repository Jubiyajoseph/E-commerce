using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
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
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly E_Commerce_DbContext _context;

        public OrderDetailController(IMediator mediator, E_Commerce_DbContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<bool>> AddOrderDetail([FromBody] AddOrderDetailCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]

        public async Task<ActionResult<OrderDetailsQuery>> GetOrderDetails(int userId)
        {
            var query = new GetOrderDetailQuery { UserId = userId };
            var orderDetails = await _mediator.Send(query);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }

        [HttpGet("search-by-date")]

        public async Task<ActionResult<OrderDetailsQuery>> GetOrderDetailsByDate(int userId,DateTime startDate,DateTime endDate)
        {
            var query = new GetOrderByDateQuery
            {
                UserId = userId,
                StartDate = startDate,
                EndDate = endDate
            };
            var orderDetailsByDate =await _mediator.Send(query);
            if(orderDetailsByDate == null)
            {
                return Ok(null);
            }
            return Ok(orderDetailsByDate);
        }

        [HttpGet("search-by-name")]
        public async Task<ActionResult<OrderDetailsQuery>> SearchOrderDetails(string searchTerm,int userId)
        {
            //var query =new GetOrderByNameQuery { SearchTerm = searchTerm };

            //var orderDetailByName =await _mediator.Send(query);

            //if(orderDetailByName == null)
            //{
            //    return Ok(null );

            //}
            //return Ok(orderDetailByName);
            var query = await _context.OrderDetail
                         .Include(od => od.Product)
                         .Include(od => od.Order)
                         .Where(od =>
                          (od.Order!.UserId == userId) &&(
                          (od.Product!.Name.Contains(searchTerm)) ||
                          (od.Product!.Brand!.Name != null && od.Product.Brand.Name.Contains(searchTerm)) ||
                          (od.Product!.Category!.Name != null && od.Product.Category.Name.Contains(searchTerm)))
                           )
                         .Select(od=>new OrderDetailsQuery
                         {
                             OrderId = od.OrderId,
                             OrderedOn=od.Order!.OrderedOn,
                             TotalPrice = od.Order!.TotalPrice,
                             ProductName = od.Product!.Name,
                             StatusName = od.Order!.OrderStatus!.Status
                         }).ToListAsync();
            if (query == null)
            {
                return Ok(null);
            }
            return Ok(query);
        }
    }
}
