using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class DeleteCartCommand:IRequest<bool>
    {
        public int CartId { get; set; } 
    }
}
