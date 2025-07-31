using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Features.Todo.Commands;

public class CreateTodoCommand : IRequest<TodoItem>
{
    public required string Description { get; set; }
    public bool IsDone { get; set; }
}