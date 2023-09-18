using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class UpdateProductStockCommandHandler : IRequestHandler<UpdateProductStockCommand, bool>
    {
        private readonly ECommerceDbContext _context;
        public UpdateProductStockCommandHandler(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateProductStockCommand command, CancellationToken cancellationToken)
        {

            var cartItems = _context.Cart
             .Where(item => (item.UserId == command.UserId) && item.OrderId == null)
             .ToList();

            bool isCartItemsTrue = await _context.Cart.Where(item => (item.UserId == command.UserId) && item.OrderId == null)
              .AnyAsync();

            if (isCartItemsTrue)
            {
                foreach (var cartItem in cartItems)
                {
                    var product = await _context.Product.FindAsync(cartItem.ProductId);

                    var productStock = await _context.Product
                      .Where(p => p.Id == cartItem.ProductId)
                      .Select(p => p.Stock).FirstOrDefaultAsync();

                    if (productStock >= cartItem.Quantity)
                    {
                        product!.UpdateStock(product.Stock - cartItem.Quantity);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

    }
}
