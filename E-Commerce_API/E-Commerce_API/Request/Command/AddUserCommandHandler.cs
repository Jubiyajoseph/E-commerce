using E_Commerce.Model.Models.UserModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddUserCommandHandler: IRequestHandler<AddUserCommand, bool>
    {
        private readonly E_Commerce_DbContext _context;

        public AddUserCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            User user = new User();
            user.Name = command.Name;
            user.Email = command.Email;
            user.Password = command.Password;
            user.Phone = command.Phone;
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
