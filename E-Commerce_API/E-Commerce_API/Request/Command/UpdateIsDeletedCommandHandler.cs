using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class UpdateIsDeletedCommandHandler : IRequestHandler<UpdateIsDeletedCommand, bool>
    {
        private readonly E_Commerce_DbContext _context; 

        public UpdateIsDeletedCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateIsDeletedCommand command, CancellationToken cancellationToken)
        {
            var address = await _context.Address.FindAsync(command.AddressId);

            if (address == null)
            {
                return false;
            }

            address.UpdateIsDeleted(true);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
