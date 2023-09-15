using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class CancelOrderCommand: IRequest<bool>
    {
        public int OrderId { get; set; }
        public  int UserId { get; set; }
        public int OrderStatusId{ get; set; }
    }
}
