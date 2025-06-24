using CQRS.Application.Features.ToDo.Queries;
using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.ToDo.Handlers;

public class GetToDoByIdHandler : IRequestHandler<GetToDoByIdQuery, ToDoItem?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetToDoByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ToDoItem?> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ToDoRepository.GetByIdAsync(request.Id);
    }
}