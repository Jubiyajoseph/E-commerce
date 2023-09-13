using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetOrderDetailQuery:IRequest<List<OrderDetailsQuery>>
    {
        public int UserId { get; set; }
    }
}
