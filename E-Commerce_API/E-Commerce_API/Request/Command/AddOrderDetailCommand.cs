using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddOrderDetailCommand: IRequest<bool>
    {
        public int OrderDetailId { get; }
        public int ProductId { get;  set; }
        public int OrderId { get;  set; }
        public int Quantity { get;  set; }
        public decimal UnitPrice { get; set; }
    }
}
