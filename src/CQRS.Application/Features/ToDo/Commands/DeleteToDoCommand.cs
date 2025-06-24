using MediatR;

namespace CQRS.Application.Features.ToDo.Commands;

public class DeleteToDoCommand : IRequest
{
    public int Id { get; set; }

    public DeleteToDoCommand(int id)
    {
        Id = id;
    }
}