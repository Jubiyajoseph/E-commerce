using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetUserIDQuery:IRequest<CartDetailsQuery>
    {
        public int UserId { get; set; }
    }
}
