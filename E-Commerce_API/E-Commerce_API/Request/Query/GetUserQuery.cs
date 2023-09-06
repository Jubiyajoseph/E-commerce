using E_Commerce_API.Request.Command;
using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetUserQuery: IRequest<GetUserIDQuery>
    {
        public string? Name { get; set; }
    }
}
