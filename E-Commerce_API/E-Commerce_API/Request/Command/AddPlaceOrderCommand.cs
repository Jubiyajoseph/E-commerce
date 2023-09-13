using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddPlaceOrderCommand:IRequest<bool>
    {
        public DateTime OrderedOn { get; set; }
        public int UserId { get; set; }
        public int BillingAddressId { get; set; }
        public int ShippingAddressId { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatusId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
