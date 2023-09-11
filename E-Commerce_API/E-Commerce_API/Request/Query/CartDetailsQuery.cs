namespace E_Commerce_API.Request.Query
{
    public class CartDetailsQuery
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
         public decimal Weight { get; set; }
        public int Stock {get; set; }
        public int Quantity { get; set; }   

    }
}
