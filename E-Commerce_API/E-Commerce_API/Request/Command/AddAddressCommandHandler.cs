using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, bool>
    {
        private readonly ECommerceDbContext _context;
        public AddAddressCommandHandler(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddAddressCommand command, CancellationToken cancellationToken)
        {
            Address address = new (command.ResidentialAddress, command.CityId,command.StateId,command.CountryId,command.UserId,command.IsDeleted,command.IsDefault);  
            _context.Address.Add(address);
            await _context.SaveChangesAsync(cancellationToken);  
            return true;    
        }
    }
}
