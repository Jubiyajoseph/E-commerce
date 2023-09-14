using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class AddPlaceOrderCommandHandler:IRequestHandler<AddPlaceOrderCommand,bool>
    {
        private readonly E_Commerce_DbContext _context;
        private readonly IMediator _mediator;

        public AddPlaceOrderCommandHandler(E_Commerce_DbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AddPlaceOrderCommand command,CancellationToken cancellationToken)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            var totalPrice = await _mediator.Send(new GetCartTotalPriceByUserIdQuery { UserId = command.UserId });
           
            try
            {

                Order order = new(command.OrderedOn,
                                  command.UserId,
                                  command.BillingAddressId,
                                  command.ShippingAddressId,
                                  totalPrice,
                                  command.OrderStatusId);

                if (order != null)
                {
                    _context.Order.Add(order);
                    await _context.SaveChangesAsync(cancellationToken);

                    // Get the newly generated OrderId
                    int newOrderId = order.OrderId;

                    // Get all items in the cart for the user where OrderId is null
                    var cartItems = _context.Cart
                        .Where(cartItem => cartItem.UserId == command.UserId && cartItem.OrderId == null)
                        .ToList();

                    //iterate through cart items
                    foreach (var cartItem in cartItems)
                    {
                        // Create an OrderDetail entry for each cart item   
                        OrderDetail orderDetail = new();

                        //geting unitprice for each product id
                        decimal unitPrice = await _context.Product
                                                    .Where(p => p.Id == cartItem.ProductId)
                                                    .Select(p => p.UnitPrice) 
                                                    .FirstOrDefaultAsync();

                        orderDetail.AddOrderDetails(cartItem.ProductId,
                                                    newOrderId,
                                                    cartItem.Quantity, 
                                                    unitPrice);

                        _context.OrderDetail.Add(orderDetail);
                    }

                    //update stock of each product in product table. 
                    var isStockUpdated = await _mediator.Send(new UpdateProductStockCommand { UserId = command.UserId });

                    // Update the Cart table to link the cart items to the new order

                    foreach (var cartItem in cartItems)
                    {
                        //  cartItem.OrderId = newOrderId;
                        cartItem.UpdateOrderIdInCart(newOrderId);

                    } 

                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit the transaction
                    await transaction.CommitAsync(cancellationToken);

                    return true;
                }
                else
                {
                    return false;
                }


            }

            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
           
        }
            
    }
}
