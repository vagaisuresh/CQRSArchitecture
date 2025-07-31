using CQRS.Application.Features.Todo.Queries;
using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.Todo.Handlers;

public class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, TodoItem?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTodoByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TodoItem?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TodoRepository.GetByIdAsync(request.Id);
    }
}