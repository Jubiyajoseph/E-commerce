using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetCartQuantityByUserIdQueryHandler : IRequestHandler<GetCartQuantityByUserIdQuery, bool>
    {
        private readonly E_Commerce_DbContext _context;
        public GetCartQuantityByUserIdQueryHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(GetCartQuantityByUserIdQuery request, CancellationToken cancellationToken)
        {

            var cartItems = await _context.Cart
                .Where(item => item.UserId == request.UserId)
                //.Select(item => new CartItems
                //{
                //    ProductId = item.ProductId,
                //    Quantity = item.Quantity
                //})
                .ToListAsync();

            foreach(var cartItem in cartItems) 
            {
                var product = await _context.Product.FindAsync(cartItem.ProductId);

                var productStock = await _context.Product
                    .Where(p=> p.Id == cartItem.ProductId)
                    .Select(p => p.Stock).FirstOrDefaultAsync();

                if(productStock > cartItem.Quantity) 
                {
                    product!.UpdateStock(product.Stock - cartItem.Quantity);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
