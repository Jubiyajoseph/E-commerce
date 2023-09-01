using E_Commerce.Model.Models.ProductsModel;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddProductCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Weight { get; set; }
        public int Stock { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
