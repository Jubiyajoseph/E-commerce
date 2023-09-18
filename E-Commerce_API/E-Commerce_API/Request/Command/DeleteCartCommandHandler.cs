using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class DeleteCartCommandHandler:IRequestHandler<DeleteCartCommand,bool>
    {
        private readonly ECommerceDbContext _context;

        public DeleteCartCommandHandler(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteCartCommand command,CancellationToken cancellationToken)
        {


            int? cartId = command.CartId;
            if ( cartId != null ) {

                var cartItem = await _context.Cart.FindAsync(cartId);
                if (cartItem != null)
                {
                    _context.Cart.Remove(cartItem);
                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
           return false;
        }

    }
}
