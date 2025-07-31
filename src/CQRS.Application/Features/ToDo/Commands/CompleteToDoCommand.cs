using MediatR;

namespace CQRS.Application.Features.Todo.Commands;

public class CompleteTodoCommand : IRequest<bool>
{
    public int Id { get; set; }

    public CompleteTodoCommand(int id)
    {
        Id = id;
    }
}