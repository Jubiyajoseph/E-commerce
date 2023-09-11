using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class UpdateAddressCommand: IRequest<bool>
    {
        public int AddressId { get; set; } // ID of the address to update
        public string? ResidentialAddress { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int UserId { get; set; }
    }
}
