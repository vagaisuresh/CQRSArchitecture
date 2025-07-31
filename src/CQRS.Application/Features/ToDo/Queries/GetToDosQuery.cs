using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Features.Todo.Queries;

public record GetTodosQuery : IRequest<IEnumerable<TodoItem>>
{
}