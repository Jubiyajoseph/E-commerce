using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddPlaceOrderCommandHandler:IRequestHandler<AddPlaceOrderCommand,bool>
    {
        private readonly E_Commerce_DbContext _context;

        public AddPlaceOrderCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddPlaceOrderCommand command,CancellationToken cancellationToken)
        {
            Order order = new(command.OrderedOn ,
                              command.UserId,
                              command.BillingAddressId,
                              command.ShippingAddressId, 
                              command.TotalPrice, 
                              command.OrderStatusId);

            if (order != null)
            {
                _context.Order.Add(order);
                await _context.SaveChangesAsync(cancellationToken);

                var orderId= order.OrderId;
                OrderDetail orderDetail = new(command.ProductId, orderId, command.Quantity, command.UnitPrice);

                if(orderDetail != null) 
                {
                    _context.OrderDetail.Add(orderDetail);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
               
            }
            return false;
        }
    }
}
