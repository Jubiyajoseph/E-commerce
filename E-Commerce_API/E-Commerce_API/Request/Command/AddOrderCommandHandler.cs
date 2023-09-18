using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, bool>
    {
        private readonly ECommerceDbContext _context;
        public AddOrderCommandHandler(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            Order order = new(command.OrderedOn, command.UserId, command.BillingAddressId, command.ShippingAddressId, command.TotalPrice, command.OrderStatusId);
            _context.Order.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
