using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserManagementApi.Data;
using UserManagementApi.Models;
using UserManagementApi.Requests;
using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly UserContext _context;

        public UpdateUserHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null)
            {
                return Unit.Value;
            }

            user.Username = request.Username;
            user.Password = request.Password;
            user.Email = request.Email;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}