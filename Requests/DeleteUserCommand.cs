using MediatR;

namespace UserManagementApi.Requests
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}

