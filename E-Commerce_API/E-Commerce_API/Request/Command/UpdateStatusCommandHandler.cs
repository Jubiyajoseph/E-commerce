using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class UpdateStatusCommandHandler:IRequestHandler<UpdateStatusCommand,bool>
    {
        public readonly E_Commerce_DbContext _context;

        public UpdateStatusCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStatusCommand command,CancellationToken cancellationToken)
        {
            var orderId = await _context.Order.FindAsync(command.OrderId);
            if (orderId == null)
            {
                return false;
            }
           
            orderId.UpdateOrder(command.OrderStatusId);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
