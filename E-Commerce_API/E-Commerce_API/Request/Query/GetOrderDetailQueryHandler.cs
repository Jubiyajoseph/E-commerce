using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetOrderDetailQueryHandler:IRequestHandler<GetOrderDetailQuery, List<OrderDetailsQuery>>
    {
        private readonly ECommerceDbContext _context;

        public GetOrderDetailQueryHandler(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetailsQuery>> Handle(GetOrderDetailQuery query,CancellationToken cancellationToken)
        {
            var orderDetails= await _context.OrderDetail
                               .Include(o=>o.Order)
                               .Include(o=>o.Product)
                               .Where(o=>o.Order!.UserId== query.UserId)
                               .Select(o=> new OrderDetailsQuery
                                {
                                   OrderId=o.OrderId,
                                    OrderedOn=o.Order!.OrderedOn,
                                    TotalPrice=o.Order!.TotalPrice,
                                    ProductName=o.Product!.Name,
                                   StatusName = o.Order!.OrderStatus!.Status
                               }).ToListAsync(cancellationToken);

            if(orderDetails==null)
            {
                throw new NotFoundException("orderDetails not found");
            }
            return orderDetails;
        }
    }
}
