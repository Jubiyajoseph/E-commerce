
namespace E_Commerce.Model.Models.OrderModel
{
    public class OrderStatus
    {
        public int OrderStatusId { get;  }
        public string Status { get; private set; }

        public OrderStatus(string status)
        {
            Status = status;
        }
    }

    

}
