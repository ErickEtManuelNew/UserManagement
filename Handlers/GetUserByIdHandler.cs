using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserManagementApi.Data;
using UserManagementApi.Models;
using UserManagementApi.Requests;

namespace UserManagementApi.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly UserContext _context;

        public GetUserByIdHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(request.Id);
        }
    }
}

