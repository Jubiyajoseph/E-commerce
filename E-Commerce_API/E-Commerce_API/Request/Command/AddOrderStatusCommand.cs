using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddOrderStatusCommand: IRequest<bool>
    {
        public int OrderStatusId { get; }
        public string? Status { get; set; }
    }
}
