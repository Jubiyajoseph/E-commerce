using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetOrderByDatequeryHandler:IRequestHandler<GetOrderByDateQuery,List<OrderDetailsQuery>>
    {
        public readonly E_Commerce_DbContext _context;

        public GetOrderByDatequeryHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDetailsQuery>> Handle(GetOrderByDateQuery query,CancellationToken cancellationToken)
        {
            var orderDetailsByDate =  await _context.OrderDetail
                                    .Include(o=>o.Order)
                                    .Include(o => o.Product)
                                    .Where(o=> (o.Order!.OrderedOn >= query.StartDate && o.Order!.OrderedOn <= query.EndDate) && o.Order!.UserId ==query.UserId)
                                    .Select(o=> new OrderDetailsQuery
                                    {
                                        OrderId = o.OrderId,
                                        OrderedOn = o.Order!.OrderedOn,
                                        TotalPrice = o.Order!.TotalPrice,
                                        ProductName = o.Product!.Name,
                                        StatusName = o.Order!.OrderStatus!.Status
                                    })
                                    .ToListAsync(cancellationToken);
           if(orderDetailsByDate == null )
            {
                throw new NotFoundException("orderDetails not found");
            }
            return orderDetailsByDate;
        }
    }
}
