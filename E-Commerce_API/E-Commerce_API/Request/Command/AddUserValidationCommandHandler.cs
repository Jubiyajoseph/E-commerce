using E_Commerce.Model.Models.UserModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddUserValidationCommandHandler:IRequestHandler<AddUserValidationCommand,bool>
    {
        private readonly UserAuthentication _userAuthentication;

        public AddUserValidationCommandHandler(UserAuthentication userAuthentication)
        {
            _userAuthentication = userAuthentication;
        }


        public async Task<bool> Handle(AddUserValidationCommand command, CancellationToken cancellationToken)
        {
            UserValidation userValidation =new UserValidation();
            userValidation.Name = command.Name; 
            userValidation.Password = command.Password;
            if( _userAuthentication.ValidateCredentials(userValidation.Name, userValidation.Password))
            {
                 var result = new Result { Message = "Login successful!" };
                 return await Task.FromResult(true);
            }
            else
            {
                var result = new Result { Message = "Invalid credentials." };
                return await Task.FromResult(false);
            }


        }
    }
}
