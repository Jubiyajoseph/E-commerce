using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class AddCartCommandHandler : IRequestHandler<AddCartCommand, bool>
    {
        private readonly E_Commerce_DbContext _context;
        public AddCartCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddCartCommand command, CancellationToken cancellationToken)
        {

            bool isAlreadyInCart = await _context.Cart.AnyAsync(c=>c.UserId==command.UserId && c.ProductId==command.ProductId && c.OrderId == null,cancellationToken);
            bool isQuantity = await _context.Product.Where(p=>p.Id==command.ProductId).AnyAsync(p=>p.Stock >= command.Quantity);

            if (isAlreadyInCart)
            {

                return false;
            }

            if (isQuantity) 
            { 
            Cart cart = new(command.UserId, command.ProductId, command.Quantity);
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
            }
            else
            {
                return false;
            }
        }
    }
}
