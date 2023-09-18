using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddOrderStatusCommandHandler : IRequestHandler<AddOrderStatusCommand, bool>
    {
        private readonly ECommerceDbContext _context;
        public AddOrderStatusCommandHandler(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddOrderStatusCommand command, CancellationToken cancellationToken)
        {
            OrderStatus orderStatus = new(command.Status!);
            _context.OrderStatus.Add(orderStatus);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
