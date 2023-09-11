using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class AddWishListCommandHandler:IRequestHandler<AddWishListCommand,bool>
    {
        private readonly E_Commerce_DbContext _context;

        public AddWishListCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddWishListCommand command, CancellationToken cancellationToken)
        {
            //only one user & one productid & isdeleted 0 can add to wishlist table
            bool isAlreadyInWishList= await _context.WishList.AnyAsync(w=>w.UserID==command.UserID && w.ProductID==command.ProductID,cancellationToken);
            if (isAlreadyInWishList)
            {
                return false;
            }

            WishList wishList = new(command.WishListId, command.UserID, command.ProductID, command.IsDeleted);
            _context.WishList.Add(wishList);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
