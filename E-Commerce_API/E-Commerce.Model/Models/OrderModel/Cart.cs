using E_Commerce.Model.Models.ProductsModel;
using E_Commerce.Model.Models.UserModel;


namespace E_Commerce.Model.Models.OrderModel
{
    public class Cart
    {
        public int CartId { get; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ProductId { get; private set; }
        public Product? Product { get; set; }
        public int Quantity { get; private set; }
        public int? OrderId { get; private set; } = null;
        public Order? Order { get; set; }

        public Cart(int userId, int productId, int quantity)
        {
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
        }
        public Cart(int userId,int productId,int quantity,int ordrerId)
        {
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
            OrderId = ordrerId;
        }
    }
}
