using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class UpdateIsDefaultCommandHandler : IRequestHandler<UpdateIsDefaultCommand, bool>
    {
        private readonly ECommerceDbContext _context;

        public UpdateIsDefaultCommandHandler(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateIsDefaultCommand request, CancellationToken cancellationToken)
        {
            // Set isDefault to false for all other addresses
            var otherAddresses = _context.Address
                .Where(a=> a.UserId == request.UserId && a.AddressId != request.AddressId);

            foreach (var address in otherAddresses)
            {
                address.UpdateIsDefault(false);
            }

            var selectedAddress = await _context.Address.FindAsync(request.AddressId);
            if (selectedAddress != null)
            {
                selectedAddress.UpdateIsDefault(true);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
