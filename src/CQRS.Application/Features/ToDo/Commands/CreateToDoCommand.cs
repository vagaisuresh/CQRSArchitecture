using MediatR;

namespace CQRS.Application.Features.ToDo.Commands;

public class CreateToDoCommand : IRequest
{
    public required string Description { get; set; }
}