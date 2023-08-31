using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, bool>
    {
        private readonly E_Commerce_DbContext _context;
        public AddAddressCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddAddressCommand command, CancellationToken cancellationToken)
        {
            Address address = new Address();  
            address.ResidentialAddress = command.ResidentialAddress;
            address.CityId = command.CityId;    
            address.StateId = command.StateId;
            address.CountryId = command.CountryId;
            address.UserId = command.UserId;
            address.IsDeleted = command.IsDeleted;
            _context.Address.Add(address);
            await _context.SaveChangesAsync();  
            return true;    
        }
    }
}
