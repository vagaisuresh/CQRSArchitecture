using CQRS.Application.Exceptions;
using CQRS.Application.Features.ToDo.Commands;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.ToDo.Handlers;

public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateToDoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateToDoCommand updateToDoCommand, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.ToDoRepository.GetByIdAsync(updateToDoCommand.Id);

        if (item == null)
            throw new NotFoundException("ToDo item not found");

        item.Description = updateToDoCommand.Description;
        item.IsDone = updateToDoCommand.IsDone;

        _unitOfWork.ToDoRepository.UpdateAsync(item);
        await _unitOfWork.SaveAsync();
    }
}