using CQRS.Application.Features.Todo.Commands;
using CQRS.Application.Features.Todo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var todos = await _mediator.Send(new GetTodosQuery());

        if (todos == null || !todos.Any())
            return NoContent();

        return Ok(todos);
    }

    [HttpGet("{id:int}", Name = "GetTodoById")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if (id == 0)
            return BadRequest("Invalid id provided.");

        var todo = await _mediator.Send(new GetTodoByIdQuery(id));

        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateTodoCommand createTodoCommand)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdTodo = await _mediator.Send(createTodoCommand);

        if (createdTodo == null)
            return BadRequest("Todo creation failed.");

        return CreatedAtRoute("GetTodoById", new { id = createdTodo.Id }, createdTodo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateTodoCommand updateTodoCommand)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data received.");

        if (id <= 0 || id != updateTodoCommand.Id)
            return BadRequest("Invalid id provided.");

        await _mediator.Send(updateTodoCommand);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id == 0)
            return BadRequest("ID in route cannot be zero.");

        await _mediator.Send(new DeleteTodoCommand(id));
        return NoContent();
    }

    [HttpPatch("{id}/complete")]
    public async Task<IActionResult> CompleteAsync(int id)
    {
        if (id == 0)
            return BadRequest("ID in route cannot be zero.");
        
        var result = await _mediator.Send(new CompleteTodoCommand(id));

        if (!result)
            return NotFound("Todo item not found.");
        
        return NoContent();
    }
}