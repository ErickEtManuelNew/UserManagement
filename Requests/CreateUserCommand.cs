using MediatR;
using UserManagementApi.Models;

namespace UserManagementApi.Requests
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}