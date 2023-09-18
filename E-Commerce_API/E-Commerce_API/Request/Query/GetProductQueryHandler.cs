using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDetailsQuery>
    {
        private readonly ECommerceDbContext _context;
        public GetProductQueryHandler(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<ProductDetailsQuery> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.Product
                .Include(p=>p.Brand)
                .Include(p=>p.Category)
                .Where(p => p.Id == query.ProductID)
                .Select(p => new ProductDetailsQuery
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    Weight = p.Weight,
                    Stock = p.Stock,
                    BrandName  = p.Brand!.Name,
                    CategoryName= p.Category!.Name,
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
