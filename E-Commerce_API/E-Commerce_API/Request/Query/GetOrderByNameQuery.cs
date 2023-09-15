using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetOrderByNameQuery : IRequest<List<OrderDetailsQuery>>
    {
        public int UserId { get; set; } 
        public string? SearchTerm { get; set; }
    }
}
