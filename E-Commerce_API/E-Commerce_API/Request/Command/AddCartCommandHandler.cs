using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;

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
            Cart cart = new(command.UserId, command.ProductId, command.Quantity, command.OrderId);
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
