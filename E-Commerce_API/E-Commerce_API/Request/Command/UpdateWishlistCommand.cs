using E_Commerce.Repository.Migrations;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class UpdateWishlistCommand:IRequest<bool>
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }  

    }
}
