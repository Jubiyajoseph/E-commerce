using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class UpdateProductStockCommandHandler : IRequestHandler<UpdateProductStockCommand, bool>
    {
        private readonly E_Commerce_DbContext _context;
        public UpdateProductStockCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateProductStockCommand command, CancellationToken cancellationToken)
        {
            
            var cartItems =  _context.Cart
               .Where(item => (item.UserId == command.UserId) && item.OrderId == null)
               .ToList();

            if(cartItems != null) 
            {
                foreach (var cartItem in cartItems)
                {
                    var product = await _context.Product.FindAsync(cartItem.ProductId);

                    var productStock = await _context.Product
                        .Where(p => p.Id == cartItem.ProductId)
                        .Select(p => p.Stock).FirstOrDefaultAsync();

                    if (productStock > cartItem.Quantity)
                    {
                        product!.UpdateStock(product.Stock - cartItem.Quantity);
                        await _context.SaveChangesAsync();
                    }
                }
                return true;
            }           
            return false;                 
        }

    }
}
