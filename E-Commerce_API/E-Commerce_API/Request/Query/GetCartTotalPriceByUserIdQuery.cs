using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetCartTotalPriceByUserIdQuery : IRequest<decimal>
    {
        public int UserId { get; set; }
    }
}
