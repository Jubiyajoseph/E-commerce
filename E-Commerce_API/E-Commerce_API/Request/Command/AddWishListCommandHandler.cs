using E_Commerce.Model.Models.OrderModel;
using E_Commerce.Repository.Context;
using MediatR;

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
            WishList wishList = new(command.WishListID, command.UserID, command.ProductID, command.IsDeleted);
            _context.WishList.Add(wishList);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
