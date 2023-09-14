using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Model.Models.ProductsModel;
using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetCartDetailsQueryHandler:IRequestHandler<GetUserIDQuery,List<CartDetailsQuery>>
    {
        private readonly E_Commerce_DbContext _context;

        public GetCartDetailsQueryHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<List<CartDetailsQuery>>Handle(GetUserIDQuery query,CancellationToken cancellationToken)
        {
            var cart = await _context.Cart
                            .Include(c => c.Product)
                            .Where(c => c.UserId == query.UserId && c.OrderId==null)
                            .Select(c => new CartDetailsQuery
                            {
                                CartId=c.CartId,
                                ProductId = c.ProductId,
                                ProductName = c.Product!.Name,
                                UnitPrice = c.Product.UnitPrice,
                                Weight = c.Product.Weight,
                                Stock = c.Product.Stock,
                                Quantity = c.Quantity
                            }).ToListAsync(cancellationToken);

            if(cart==null)
            {
                throw new NotFoundException("cart not found");
            }
            return cart;
        }

    }
}
