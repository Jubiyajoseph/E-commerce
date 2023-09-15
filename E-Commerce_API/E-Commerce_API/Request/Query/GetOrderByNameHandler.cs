using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    //public class GetOrderByNameHandler : IRequestHandler<GetOrderByNameQuery, List<OrderDetailsQuery>>
    //{
    //    public readonly E_Commerce_DbContext _context;

    //    public GetOrderByNameHandler(E_Commerce_DbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<List<OrderDetailsQuery>> Handle(GetOrderByNameQuery query, CancellationToken cancellationToken)
    //    {


    //        var orderDetailsByName = await _context.OrderDetail
    //                     .Include(od => od.Product)
    //                     .Where(od =>
    //                      (od.Product!.Name.Contains(query.SearchTerm)) ||
    //                      (od.Product!.Brand!.Name != null && od.Product.Brand.Name.Contains(query.SearchTerm)) ||
    //                      (od.Product!.Category!.Name != null && od.Product.Category.Name.Contains(query.SearchTerm))
    //                       ).ToListAsync(cancellationToken);
    //        return orderDetailsByName;

    //    }
    //}
}
