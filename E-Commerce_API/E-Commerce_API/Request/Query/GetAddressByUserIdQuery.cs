using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetAddressByUserIdQuery: IRequest<List<AddressDetailsQuery>>
    {
        public int UserId { get; set; }
    }
}
