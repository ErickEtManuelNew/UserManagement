using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserManagementApi.Data;
using UserManagementApi.Models;
using UserManagementApi.Requests;

namespace UserManagementApi.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly UserContext _context;

        public DeleteUserHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null)
            {
                return Unit.Value;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}