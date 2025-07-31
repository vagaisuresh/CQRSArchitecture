using MediatR;

namespace CQRS.Application.Features.Todo.Commands;

public class DeleteTodoCommand : IRequest
{
    public int Id { get; set; }

    public DeleteTodoCommand(int id)
    {
        Id = id;
    }
}