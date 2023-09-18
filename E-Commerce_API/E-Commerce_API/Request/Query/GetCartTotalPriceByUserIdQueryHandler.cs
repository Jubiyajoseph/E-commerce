using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetCartTotalPriceByUserIdQueryHandler : IRequestHandler<GetCartTotalPriceByUserIdQuery, decimal>
    {
        private readonly ECommerceDbContext _context;
        public GetCartTotalPriceByUserIdQueryHandler(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> Handle(GetCartTotalPriceByUserIdQuery request, CancellationToken cancellationToken)
        {
            var total = await _context.Cart
            .Where(item => item.UserId == request.UserId && item.OrderId == null)
            .SumAsync(item => item.Product!.UnitPrice * item.Quantity, cancellationToken);

            return total;
        }
    }
}
