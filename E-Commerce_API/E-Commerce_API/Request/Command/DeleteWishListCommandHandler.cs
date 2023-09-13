using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class DeleteWishListCommandHandler:IRequestHandler<DeleteWishListCommand,bool>
    {
        private readonly E_Commerce_DbContext _context;

        public DeleteWishListCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteWishListCommand command,CancellationToken cancellationToken)
        {
            int? wishListId=command.WishListId;
            if (wishListId.HasValue)
            {
                var wishList = await _context.WishList.FindAsync(wishListId);
                if(wishList != null) 
                {
                    _context.WishList.Remove(wishList);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            return false;
        }
    }
}
