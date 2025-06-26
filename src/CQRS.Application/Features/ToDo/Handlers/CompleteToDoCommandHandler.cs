using CQRS.Application.Features.ToDo.Commands;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.ToDo.Handlers;

public class CompleteToDoCommandHandler : IRequestHandler<CompleteToDoCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CompleteToDoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CompleteToDoCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _unitOfWork.ToDoRepository.GetByIdAsync(request.Id);
        if (todoItem == null) return false;

        todoItem.IsDone = true;

        _unitOfWork.ToDoRepository.UpdateAsync(todoItem);
        await _unitOfWork.SaveAsync(cancellationToken);

        return true;
    }
}