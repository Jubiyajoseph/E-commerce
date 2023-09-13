using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class OrderDetailsQuery
    {
        public int OrderId { get; set; }
        public DateTime OrderedOn { get; set; }
        public decimal TotalPrice { get; set; }
        public string? ProductName { get; set; }
        public string? StatusName { get; set; }
    }
}
