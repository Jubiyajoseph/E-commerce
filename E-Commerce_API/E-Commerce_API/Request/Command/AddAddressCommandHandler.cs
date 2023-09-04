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
            Address address = new (command.ResidentialAddress, command.CityId,command.StateId,command.CountryId,command.UserId,command.IsDeleted);  
            _context.Address.Add(address);
            await _context.SaveChangesAsync(cancellationToken);  
            return true;    
        }
    }
}
