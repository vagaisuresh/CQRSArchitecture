using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Features.Todo.Queries;

public record GetTodoByIdQuery(int Id) : IRequest<TodoItem>
{
}