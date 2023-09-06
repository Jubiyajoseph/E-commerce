using MediatR;
namespace E_Commerce_API.Request.Query
{
    public class ProductDetailsQuery
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Weight { get; set; }
        public int Stock { get; set; }
        public string? BrandName { get; set; }
        public string? CategoryName { get; set; } 
        public decimal UnitPrice { get; set; }
    }
}
