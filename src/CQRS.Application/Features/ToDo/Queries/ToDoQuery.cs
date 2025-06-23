using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Features.ToDo.Queries;

public class ToDoQuery : IRequest<List<ToDoItem>>
{
}