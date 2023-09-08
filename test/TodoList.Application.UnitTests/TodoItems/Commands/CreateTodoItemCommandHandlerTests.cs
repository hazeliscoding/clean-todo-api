using Moq;
using TodoList.Application.TodoItems.CreateTodoItem;
using TodoList.Domain.Abstractions;
using TodoList.Domain.TodoItems;
using TodoList.Infrastructure.Repositories;

namespace TodoList.Application.UnitTests.TodoItems.Commands;

public class CreateTodoItemCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldPersistTodoItem()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<ITodoItemRepository>();

        mockRepository.Setup(r => r.AddAsync(It.IsAny<TodoItem>())).Returns(Task.CompletedTask);

        // You can either use a real PrioritySuggestionService or mock it.
        // If you just want to test the handler logic, it's often easier to use the real service if it doesn't have external dependencies.
        var priorityService = new PrioritySuggestionService();

        var handler = new CreateTodoItemCommandHandler(mockRepository.Object, mockUnitOfWork.Object, priorityService);
        var command = new CreateTodoItemCommand
        {
            Title = "Test Task",
            DueDate = DateOnly.MinValue
        };

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepository.Verify(r => r.AddAsync(It.IsAny<TodoItem>()), Times.Once());
        mockUnitOfWork.Verify(u => u.Commit(), Times.Once());
    }
}