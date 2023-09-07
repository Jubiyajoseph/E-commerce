using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetWishListQuery: IRequest<List<WishListDetailsQuery>>
    {
        public int UserId { get; set; }
    }
}
