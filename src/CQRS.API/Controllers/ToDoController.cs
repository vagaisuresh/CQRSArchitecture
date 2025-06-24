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
        var toDos = await _mediator.Send(new GetToDosQuery());

        if (toDos == null || !toDos.Any())
            return NoContent();
        
        return Ok(toDos);
    }

    [HttpGet("{id:int}", Name = "GetToDoById")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if (id == 0)
            return BadRequest("Invalid id provided.");
        
        var toDo = await _mediator.Send(new GetToDoByIdQuery(id));

        if (toDo == null)
            return NotFound();
        
        return Ok(toDo);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateToDoCommand createToDoCommand)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data received.");
        
        var createdToDo = await _mediator.Send(createToDoCommand);

        if (createdToDo == null)
            return BadRequest("ToDo creation failed.");
        
        return CreatedAtRoute("GetToDoById", new { id = createdToDo.Id }, createdToDo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateToDoCommand updateToDoCommand)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data received.");
        
        if (id <= 0 || id != updateToDoCommand.Id)
            return BadRequest("Invalid id provided.");

        await _mediator.Send(updateToDoCommand);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id == 0)
            return BadRequest("Invalid id.");

        await _mediator.Send(new DeleteToDoCommand(id));
        return NoContent();
    }
}