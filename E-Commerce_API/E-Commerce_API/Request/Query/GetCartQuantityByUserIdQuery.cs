using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetCartQuantityByUserIdQuery: IRequest<bool>
    {
        public int UserId { get; set; }

    }
}
