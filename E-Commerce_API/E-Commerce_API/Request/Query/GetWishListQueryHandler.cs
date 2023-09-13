using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetWishListQueryHandler : IRequestHandler<GetWishListQuery, List<WishListDetailsQuery>>
    {
        private readonly E_Commerce_DbContext _context;
        public GetWishListQueryHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }
        public async Task<List<WishListDetailsQuery>> Handle(GetWishListQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.WishList
                     .Include(w =>w.Product)
                     .Where(w=>w.UserID == query.UserId && w.IsDeleted == false)
                     .Select(w => new WishListDetailsQuery
                     {
                         WishListId=w.WishListId,
                         ProductId=w.Product!.Id,                    
                         ProductName=  w.Product!.Name
                     }).ToListAsync(cancellationToken);

            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }
            return product;
        }
    }
}
