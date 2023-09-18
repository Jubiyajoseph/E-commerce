using E_Commerce.Model.Models.UserModel;
using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class AddUserValidationCommandHandler:IRequestHandler<AddUserValidationCommand,bool>
    {
        
        private readonly ECommerceDbContext _context;

        public AddUserValidationCommandHandler(ECommerceDbContext context)
        {
            _context = context;            
        }


        public async Task<bool> Handle(AddUserValidationCommand command, CancellationToken cancellationToken)
        {
            User user = new(command.Name, command.Password);

            var checkUser = await _context.User.FirstOrDefaultAsync(x => x.Name == command.Name );
            return checkUser?.Password == command.Password;
            
        }
    }
}
