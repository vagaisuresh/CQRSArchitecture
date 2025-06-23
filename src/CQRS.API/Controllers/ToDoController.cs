using CQRS.Application.Features.ToDo.Commands;
using CQRS.Application.Features.ToDo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToDoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new ToDoQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateToDoCommand createToDoCommand)
    {
        await _mediator.Send(createToDoCommand);
        return Created();
    }
}