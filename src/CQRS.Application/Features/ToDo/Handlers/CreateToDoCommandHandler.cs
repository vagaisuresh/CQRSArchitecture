using CQRS.Application.Features.ToDo.Commands;
using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.ToDo.Handlers;

public class CreateToDoCommandHandler(IToDoRepository toDoRepository) : IRequestHandler<CreateToDoCommand>
{
    public Task Handle(CreateToDoCommand command, CancellationToken cancellationToken)
    {
        var toDoItem = new ToDoItem
        {
            Description = command.Description
        };

        return toDoRepository.CreateAsync(toDoItem);
    }
}