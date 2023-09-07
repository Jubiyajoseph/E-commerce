using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Model.Models.UserModel;

namespace E_Commerce.Model.Models.OrderModel
{
    public class Order
    {
        public int OrderId { get; }
        public DateTime OrderedOn { get; private set; }
        public int UserId { get; private set; }
        public User? User { get; set; }
        public int BillingAddressId { get; private set; }
        public Address? BillingAddress { get; set; }
        public int ShippingAddressId { get; private set; }
        public Address? ShippingAddress { get; set; }
        public  decimal TotalPrice { get; private set; }
        public int OrderStatusId { get; private set; }
        public  OrderStatus? OrderStatus { get; set; }

        public Order(DateTime orderedOn,int userId,int billingAddressId, int shippingAddressId,decimal totalPrice, int orderStatusId)
        {
            OrderedOn = orderedOn;
            UserId = userId;
            BillingAddressId = billingAddressId;
            ShippingAddressId = shippingAddressId;
            TotalPrice = totalPrice;
            OrderStatusId = orderStatusId;
        }
    }
}
