using E_Commerce.Model.Models.UserModel;
using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Command
{
    public class AddUserValidationCommandHandler:IRequestHandler<AddUserValidationCommand,bool>
    {
        
        private readonly E_Commerce_DbContext _context;

        public AddUserValidationCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;            
        }


        public async Task<bool> Handle(AddUserValidationCommand command, CancellationToken cancellationToken)
        {
            User user = new(command.Name, command.Password);

            bool checkUser = await _context.User.AnyAsync(x => x.Name == command.Name && x.Password == command.Password);
            if (checkUser)
            {
                return await Task.FromResult(true);
                //return await _context.SaveChangesAsync();
            }
            else
            {               
                return await Task.FromResult(false);
            }


        }
    }
}
