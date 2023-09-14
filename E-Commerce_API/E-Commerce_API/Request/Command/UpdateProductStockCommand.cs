using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class UpdateProductStockCommand:IRequest<bool>
    {
        public int UserId { get; set; }
        
    }
}
