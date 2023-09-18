using E_Commerce.Model.Models.AddressModel;
using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetAddressByUserIdQueryHandler : IRequestHandler<GetAddressByUserIdQuery, List<AddressDetailsQuery>>
    {
        private readonly ECommerceDbContext _context;
        public GetAddressByUserIdQueryHandler(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<AddressDetailsQuery>> Handle(GetAddressByUserIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _context.Address
                .Include(a=>a.City)
                .Include(a=>a.State)
                .Include(a=>a.Country)
                .Where(a => a.UserId == request.UserId && a.IsDeleted == false)
                .Select(a => new AddressDetailsQuery
                {
                    AddressId = a.AddressId,
                    ResidentialAddress = a.ResidentialAddress,
                    CityName=a.City!.Name,
                    StateName = a.State!.Name,
                    CountryName = a.Country!.Name
                })
                .ToListAsync(cancellationToken);

            return address;
            
        }


    }
}
