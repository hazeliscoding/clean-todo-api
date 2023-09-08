using FluentAssertions;
using Moq;
using TodoList.Domain.TodoItems;
using TodoList.Domain.TodoItems.Events;

namespace TodoList.Domain.UnitTests.TodoItems;

public class TodoItemTests
{
    [Fact]
    public void MarkAsCompleted_Should_Raise_TodoItemCompletedEvent()
    {
        // Arrange
        var todoItem = new TodoItem("Test", DateOnly.FromDateTime(DateTime.UtcNow), new PrioritySuggestionService());

        // Act
        todoItem.MarkAsCompleted();

        // Assert
        var todoItemCompletedEvent = todoItem.DomainEvents.OfType<TodoItemCompletedEvent>().SingleOrDefault();
        todoItemCompletedEvent.Should().NotBeNull();
        todoItemCompletedEvent!.TodoItem.Should().Be(todoItem);
    }
}