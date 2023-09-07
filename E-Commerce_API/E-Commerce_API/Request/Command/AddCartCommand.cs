
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddCartCommand: IRequest<bool>
    {
        public int CartId { get; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}
