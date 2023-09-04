using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddAddressCommand:IRequest<bool>
    {
        public int AddressId { get; set; }
        public string ResidentialAddress { get; set; } = string.Empty;
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
