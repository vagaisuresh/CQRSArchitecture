using CQRS.Application.Exceptions;
using CQRS.Application.Features.Todo.Commands;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.Todo.Handlers;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTodoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateTodoCommand updateTodoCommand, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.TodoRepository.GetByIdAsync(updateTodoCommand.Id);

        if (item == null)
            throw new NotFoundException("Todo item not found");

        item.Description = updateTodoCommand.Description;
        item.IsDone = updateTodoCommand.IsDone;

        _unitOfWork.TodoRepository.Update(item);
        await _unitOfWork.SaveAsync();
    }
}