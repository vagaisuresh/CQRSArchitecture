using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Features.ToDo.Commands;

public class CreateToDoCommand : IRequest<ToDoItem>
{
    public required string Description { get; set; }
    public bool IsDone { get; set; }
}