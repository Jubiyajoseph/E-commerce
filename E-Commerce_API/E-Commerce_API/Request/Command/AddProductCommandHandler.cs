using E_Commerce.Model.Models.ProductsModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly E_Commerce_DbContext _context;
        public AddProductCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            Product product = new Product();
            product.Name = command.Name;
            product.Weight = command.Weight;
            product.Stock = command.Stock;
            product.BrandId = command.BrandId;
            product.CategoryId = command.CategoryId;
            product.UnitPrice = command.UnitPrice;
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
