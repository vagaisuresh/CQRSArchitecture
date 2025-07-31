using CQRS.Application.Features.Todo.Commands;
using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.Todo.Handlers;

public class CreateTodoCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateTodoCommand, TodoItem?>
{
    public async Task<TodoItem?> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        var todoItem = new TodoItem
        {
            Description = command.Description,
            IsDone = true
        };
        
        await _unitOfWork.TodoRepository.CreateAsync(todoItem);
        await _unitOfWork.SaveAsync();

        return todoItem;
    }
}