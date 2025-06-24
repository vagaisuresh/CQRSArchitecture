using CQRS.Application.Features.ToDo.Commands;
using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.ToDo.Handlers;

public class CreateToDoCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateToDoCommand, ToDoItem?>
{
    public async Task<ToDoItem?> Handle(CreateToDoCommand command, CancellationToken cancellationToken)
    {
        var toDoItem = new ToDoItem
        {
            Description = command.Description,
            IsDone = true
        };
        
        await _unitOfWork.ToDoRepository.CreateAsync(toDoItem);
        await _unitOfWork.SaveAsync();

        return toDoItem;
    }
}