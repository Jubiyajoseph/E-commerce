using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, AddProductCommand>
    {
        private readonly E_Commerce_DbContext _context;
        public GetProductQueryHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }
        public async Task<AddProductCommand> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.Product.Where(p => p.ProductId == query.ProductID)
                .Select(p => new AddProductCommand
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Weight = p.Weight,
                    Stock = p.Stock,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    UnitPrice = p.UnitPrice
                }).FirstOrDefaultAsync(cancellationToken);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }
            return product;
        }
    }
}
