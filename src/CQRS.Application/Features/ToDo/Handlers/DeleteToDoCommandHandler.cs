using CQRS.Application.Exceptions;
using CQRS.Application.Features.ToDo.Commands;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.ToDo.Handlers;

public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteToDoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteToDoCommand deleteToDoCommand, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.ToDoRepository.GetByIdAsync(deleteToDoCommand.Id);

        if (item == null)
            throw new NotFoundException($"ToDo item with ID {deleteToDoCommand.Id} not found");

        _unitOfWork.ToDoRepository.DeleteAsync(item);
        await _unitOfWork.SaveAsync();
    }
}