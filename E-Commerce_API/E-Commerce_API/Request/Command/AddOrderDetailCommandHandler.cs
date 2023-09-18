using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddOrderDetailCommandHandler : IRequestHandler<AddOrderDetailCommand, bool>
    {
        private readonly ECommerceDbContext _context;
        public AddOrderDetailCommandHandler(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddOrderDetailCommand command, CancellationToken cancellationToken)
        {
            OrderDetail orderDetail = new(command.ProductId,command.OrderId,command.Quantity,command.UnitPrice);
            _context.OrderDetail.Add(orderDetail);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
