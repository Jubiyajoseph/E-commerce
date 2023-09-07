using E_Commerce_API.Request.Command;
using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetUserNameQuery: IRequest<GetUserIDQuery>
    {
        public string? Name { get; set; }
    }
}
