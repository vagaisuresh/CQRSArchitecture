using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Features.ToDo.Queries;

public record GetToDosQuery : IRequest<IEnumerable<ToDoItem>>
{
}