using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetUserIDQueryHandler: IRequestHandler<GetUserIDQuery,List<CartDetailsQuery>>
    {
        private readonly E_Commerce_DbContext _context;

        public GetUserIDQueryHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<List<CartDetailsQuery>> Handle(GetUserIDQuery query, CancellationToken cancellationToken)
        {
            var cart = await _context.Cart
                .Include(c=>c.Product)
                .Where(c=>c.UserId == query.UserId) 
                .Select(c=>new CartDetailsQuery
                {
                    productId=c.ProductId,
                    productName=c.Product!.Name,
                    unitPrice= c.Product.UnitPrice,
                    weight= c.Product.Weight,
                    stock=c.Product.Stock,
                    quantity=c.Quantity
                }).ToListAsync(cancellationToken);
            if(cart == null )
            {
                throw new NotFoundException("Cart not found");
            }
            return cart;
        }
    }
}
