using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class UpdateIsDeletedCommand: IRequest<bool>
    {
        public int AddressId { get; set; }
    }
}
