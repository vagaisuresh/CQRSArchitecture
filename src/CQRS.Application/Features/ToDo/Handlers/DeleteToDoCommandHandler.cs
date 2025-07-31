using CQRS.Application.Exceptions;
using CQRS.Application.Features.Todo.Commands;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.Todo.Handlers;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTodoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTodoCommand deleteTodoCommand, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.TodoRepository.GetByIdAsync(deleteTodoCommand.Id);

        if (item == null)
            throw new NotFoundException($"Todo item with ID {deleteTodoCommand.Id} not found");

        _unitOfWork.TodoRepository.Delete(item);
        await _unitOfWork.SaveAsync();
    }
}