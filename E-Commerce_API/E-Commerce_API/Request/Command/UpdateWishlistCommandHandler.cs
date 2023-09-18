using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace E_Commerce_API.Request.Command
{
    public class UpdateWishlistCommandHandler:IRequestHandler<UpdateWishlistCommand,bool>
    {
        private readonly ECommerceDbContext _context;
        public UpdateWishlistCommandHandler(ECommerceDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateWishlistCommand command,CancellationToken cancellationToken)
        { 
            
            int wishListId = await _context.WishList
                .Where(w => w.ProductID == command.ProductID && w.UserID == command.UserID && w.IsDeleted==false)
                            .Select(w => w.WishListId).FirstOrDefaultAsync(cancellationToken);

            var wishList = await _context.WishList.FindAsync(wishListId);

                if (wishList == null)
                {
                    return false;
                }
                wishList.UpdateIsDeleted(true);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
        }
    }
}
