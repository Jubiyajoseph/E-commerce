using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class DeleteWishListCommand:IRequest<bool>
    {
        public int WishListId { get; set; }
    }
}
