using CQRS.API.Controllers;
using CQRS.Application.Features.Todo.Handlers;
using CQRS.Application.Features.Todo.Queries;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CQRS.API.Tests.Controllers;

public class TodosControllerTest
{
    private readonly TodosController _controller;
    private readonly Mock<CreateTodoCommandHandler> _handlerMock;
    private readonly Mock<IMediator> _mediatorMock;

    public TodosControllerTest()
    {
        _handlerMock = new Mock<CreateTodoCommandHandler>();
        _mediatorMock = new Mock<IMediator>();
        //_controller = new TodosController(_handlerMock.Object, _mediatorMock.Object);
        _controller = new TodosController(null!, _mediatorMock.Object); // Using null! for handler as it's not used in this test
    }

    [Fact]
    public async Task GetById_UnknownIdPassed_ReturnsNotFoundResult()
    {
        // Arrange
        var unknownId = 1000000;

        // Act
        var notFoundResult = await _controller.GetByIdAsync(unknownId);

        // Assert
        Assert.IsType<NotFoundResult>(notFoundResult);
    }

    [Fact]
    public async Task GetById_ExistingIdPassed_ReturnsOkResult()
    {
        // Arrange
        var testId = 100000;
        var expectedItem = new TodoItem { Id = testId, Description = "Test", IsDone = false };

        var mediatorMock = new Mock<IMediator>();
        mediatorMock
            .Setup(m => m.Send(It.Is<GetTodoByIdQuery>(q => q.Id == testId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedItem);

        var controller = new TodosController(null!, mediatorMock.Object);

        // Act
        var result = await controller.GetByIdAsync(testId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualItem = Assert.IsType<TodoItem>(okResult.Value);
        Assert.Equal(testId, actualItem.Id);
    }

    [Fact]
    public async Task Get_WhenCalled_ReturnsOkResult()
    {
        // Arrange
        var _mediatorMock = new Mock<IMediator>();
        var expectedTodos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Description = "Test", IsDone = false }
        };

        // Mocking Send for GetTodosQuery
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetTodosQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedTodos);

        // Controller doesn't use CreateTodoCommandHandler in this method, so null is OK
        var controller = new TodosController(null!, _mediatorMock.Object);

        // Act
        var result = await controller.GetAllAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var todos = Assert.IsAssignableFrom<IEnumerable<TodoItem>>(okResult.Value);
        Assert.Single(todos); // Optional: check count
    }
}