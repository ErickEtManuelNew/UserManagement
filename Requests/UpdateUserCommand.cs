using MediatR;
using UserManagementApi.Models;

namespace UserManagementApi.Requests
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UpdateUserCommand(int id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}

