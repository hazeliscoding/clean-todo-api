using Moq;
using TodoList.Application.TodoItems;
using TodoList.Application.TodoItems.GetTodoItem;
using TodoList.Domain.TodoItems;

namespace TodoList.Application.UnitTests.TodoItems.Queries;

public class GetTodoItemByIdQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnCorrectTodoItem()
    {
        // Arrange
        var todoItem = new TodoItem("Test", DateOnly.MinValue, new PrioritySuggestionService());
        var todoItemDto = new TodoItemResponse
        {
            Id = todoItem.Id,
            Title = todoItem.Title,
            DueDate = todoItem.DueDate,
            IsCompleted = todoItem.IsCompleted,
            Priority = todoItem.Priority
        }; 

        var mockRepository = new Mock<ITodoItemRepository>();

        mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(todoItem);

        var handler = new GetTodoItemByIdQueryHandler(mockRepository.Object);

        var query = new GetTodoItemByIdQuery
        {
            Id = 1
        };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(todoItemDto.Title, result.Title);
        Assert.Equal(todoItemDto.DueDate, result.DueDate);
        Assert.Equal(todoItemDto.IsCompleted, result.IsCompleted);
        Assert.Equal(todoItemDto.Priority, result.Priority);
    }
}