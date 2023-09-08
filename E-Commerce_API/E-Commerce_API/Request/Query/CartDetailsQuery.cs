namespace E_Commerce_API.Request.Query
{
    public class CartDetailsQuery
    {
        public int productId { get; set; }
        public string? productName { get; set; }
        public int unitPrice { get; set; }
        public int stock {get; set; }
        public int quantity { get; set; }   

    }
}
