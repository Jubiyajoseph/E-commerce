using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, bool>
    {
        private readonly E_Commerce_DbContext _context;

        public CancelOrderCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {           

            bool isUserCancelled = await _context.Order
                .Where(u => u.UserId == request.UserId && u.OrderStatusId == request.OrderStatusId 
                && u.OrderId == request.OrderId).AnyAsync();

            if(isUserCancelled)
            {
                var orderDetails = await _context.OrderDetail                
                    .Where(od => od.OrderId == request.OrderId )
                    .ToListAsync();

                foreach( var item in orderDetails)
                {
                    bool isProductInTable = await _context.Product
                        .Where(p=> p.Id == item.ProductId).AnyAsync();

                    var product = await _context.Product.FindAsync(item.ProductId);

                    if (isProductInTable) 
                    {
                        product!.UpdateStock(product.Stock + item.Quantity);
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
