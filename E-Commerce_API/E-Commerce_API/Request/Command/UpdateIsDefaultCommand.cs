using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class UpdateIsDefaultCommand : IRequest<bool>
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
    }
}
