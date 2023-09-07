using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddWishListCommand:IRequest<bool>
    {
        public int WishListId { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
