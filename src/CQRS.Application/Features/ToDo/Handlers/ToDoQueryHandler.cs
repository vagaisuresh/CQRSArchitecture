using CQRS.Application.Features.ToDo.Queries;
using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.ToDo.Handlers;

public class ToDoQueryHandler(IToDoRepository toDoRepository) : IRequestHandler<ToDoQuery, List<ToDoItem>>
{
    public Task<List<ToDoItem>> Handle(ToDoQuery toDoQuery, CancellationToken cancellationToken)
    {
        return toDoRepository.GetAllAsync();
    }
}