using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetProductStockStatusQuery: IRequest<int>
    {
        public int ProductId { get; set; }
    }
}
