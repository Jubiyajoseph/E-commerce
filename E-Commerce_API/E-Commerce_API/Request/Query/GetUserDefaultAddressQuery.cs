using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetUserDefaultAddressQuery: IRequest<AddressDetailsQuery>
    {
        public int UserId { get; set; }
    }
}
