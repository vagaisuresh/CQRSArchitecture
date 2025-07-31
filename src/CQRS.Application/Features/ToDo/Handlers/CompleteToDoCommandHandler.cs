using CQRS.Application.Features.Todo.Commands;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.Todo.Handlers;

public class CompleteTodoCommandHandler : IRequestHandler<CompleteTodoCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CompleteTodoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _unitOfWork.TodoRepository.GetByIdAsync(request.Id);
        if (todoItem == null) return false;

        todoItem.IsDone = true;

        _unitOfWork.TodoRepository.Update(todoItem);
        await _unitOfWork.SaveAsync(cancellationToken);

        return true;
    }
}