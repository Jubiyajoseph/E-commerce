using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetOrderByDateQuery:IRequest<List<OrderDetailsQuery>>
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
    }
}
