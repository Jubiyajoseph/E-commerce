using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class UpdateAddressCommandHandler: IRequestHandler<UpdateAddressCommand,bool>
    {
        private readonly ECommerceDbContext _context;

        public UpdateAddressCommandHandler(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateAddressCommand command, CancellationToken cancellationToken)
        {
            // Fetch the address by ID and update its properties
            var addressId = await _context.Address.FindAsync(command.AddressId);

            if (addressId == null)
            {
                return false; 
            }

            addressId.UpdateAddress(command.ResidentialAddress!,command.CityId,command.StateId,command.CountryId,command.UserId);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }

}
