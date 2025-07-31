using CQRS.Application.Features.Todo.Queries;
using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.Todo.Handlers;

public class GetTodoQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetTodosQuery, IEnumerable<TodoItem>>
{
    public async Task<IEnumerable<TodoItem>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TodoRepository.GetAllAsync();
    }
}