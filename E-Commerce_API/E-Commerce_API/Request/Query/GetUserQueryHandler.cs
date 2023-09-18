using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserNameQuery, GetUserIDQuery>
    {
        private readonly ECommerceDbContext _context;
        public GetUserQueryHandler(ECommerceDbContext context)
        {
            _context = context;
        }       

        public async Task<GetUserIDQuery> Handle(GetUserNameQuery query, CancellationToken cancellationToken)
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
