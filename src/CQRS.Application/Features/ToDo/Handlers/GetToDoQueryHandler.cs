using CQRS.Application.Features.ToDo.Queries;
using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Features.ToDo.Handlers;

public class GetToDoQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetToDosQuery, IEnumerable<ToDoItem>>
{
    public async Task<IEnumerable<ToDoItem>> Handle(GetToDosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ToDoRepository.GetAllAsync();
    }
}