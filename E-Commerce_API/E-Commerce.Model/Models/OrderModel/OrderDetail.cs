using E_Commerce.Model.Models.ProductsModel;

namespace E_Commerce.Model.Models.OrderModel
{
    public class OrderDetail
    {
        public int OrderDetailId { get; }
        public int ProductId { get; private set; }
        public  Product? Product { get; set; }
        public  int OrderId { get; private set; }
        public Order? Order { get; set; }
        public int Quantity { get; private set; }
        public  decimal UnitPrice { get; private set; }

        public OrderDetail(int productId,int orderId, int quantity,decimal unitPrice)
        {
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity; 
            UnitPrice=unitPrice;
        }
    }
}
