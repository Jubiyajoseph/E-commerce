using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetProductStockStatusQueryHandler: IRequestHandler<GetProductStockStatusQuery,int>
    {
        private readonly ECommerceDbContext _context;
        public GetProductStockStatusQueryHandler(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(GetProductStockStatusQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Product.FindAsync(request.ProductId);
            return product!.Stock;
        }
    }
}
