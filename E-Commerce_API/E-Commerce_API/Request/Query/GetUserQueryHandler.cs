using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserIDQuery>
    {
        private readonly E_Commerce_DbContext _context;
        public GetUserQueryHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }       

        public async Task<GetUserIDQuery> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var userId = await _context.User.Where(u => u.Name == query.Name)
                .Select(u => new GetUserIDQuery
                {
                    UserId = u.UserId
                }).FirstOrDefaultAsync(cancellationToken);

            if (userId == null)
            {
                throw new NotFoundException("UserId not found");
            }
            
            return userId;
        }
    }
}
