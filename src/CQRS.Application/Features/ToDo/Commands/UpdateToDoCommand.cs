using MediatR;

namespace CQRS.Application.Features.Todo.Commands;

public class UpdateTodoCommand : IRequest
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public bool IsDone { get; set; }
}