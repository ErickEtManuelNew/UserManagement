using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserManagementApi.Data;
using UserManagementApi.Models;
using UserManagementApi.Requests;

namespace UserManagementApi.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly UserContext _context;

        public CreateUserHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}

