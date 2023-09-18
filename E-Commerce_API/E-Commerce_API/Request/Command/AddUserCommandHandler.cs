using E_Commerce.Model.Models.UserModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddUserCommandHandler: IRequestHandler<AddUserCommand, bool>
    {
        private readonly ECommerceDbContext _context;

        public AddUserCommandHandler(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            User user = new (command.Name,command.Email,command.Phone,command.Password);
            _context.User.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
