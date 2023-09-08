namespace E_Commerce_API.Request.Query
{
    public class CartDetailsQuery
    {
        public int productId { get; set; }
        public string? productName { get; set; }
        public decimal unitPrice { get; set; }
         public decimal weight { get; set; }
        public int stock {get; set; }
        public int quantity { get; set; }   

    }
}
