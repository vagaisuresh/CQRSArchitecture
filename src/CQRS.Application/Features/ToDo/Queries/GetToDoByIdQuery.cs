using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Features.ToDo.Queries;

public record GetToDoByIdQuery(int Id) : IRequest<ToDoItem>
{
}