using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            decimal totalPrice=1888;
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
