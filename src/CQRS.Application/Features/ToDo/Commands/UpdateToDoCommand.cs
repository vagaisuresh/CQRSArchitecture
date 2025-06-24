using MediatR;

namespace CQRS.Application.Features.ToDo.Commands;

public class UpdateToDoCommand : IRequest
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public bool IsDone { get; set; }
}