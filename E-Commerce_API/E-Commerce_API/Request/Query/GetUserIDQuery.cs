using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetUserIDQuery:IRequest<List<CartDetailsQuery>>
    {
        public int UserId { get; set; }
    }
}
