using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddUserValidationCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
