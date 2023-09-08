
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddOrderCommand: IRequest<bool>
    {
        public int OrderId { get; }
        public DateTime OrderedOn { get; set; }
        public int UserId { get; set; }
        public int BillingAddressId { get; set; }
        public int ShippingAddressId { get; set; }
        public decimal TotalPrice { get;  set; }
        public int OrderStatusId { get;  set; }
    }
}
