using MediatR;

namespace CQRS.Application.Features.ToDo.Commands;

public class CompleteToDoCommand : IRequest<bool>
{
    public int Id { get; set; }

    public CompleteToDoCommand(int id)
    {
        Id = id;
    }
}