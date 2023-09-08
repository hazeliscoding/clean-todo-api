using TodoList.Domain.TodoItems;

namespace TodoList.Domain.UnitTests.TodoItems;

public class PrioritySuggestionServiceTests
{
    [Theory]
    [InlineData(5, "Low")]
    [InlineData(0, "High")]
    [InlineData(1, "High")]
    [InlineData(2, "Medium")]
    public void SuggestPriority_ShouldReturnExpectedPriority(int daysUntilDue, string expectedPriority)
    {
        // Arrange
        var service = new PrioritySuggestionService();
        var dueDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(daysUntilDue));
        var todo = new TodoItem("Test task", dueDate, service);

        // Act
        var priority = service.SuggestPriority(todo);

        // Assert
        Assert.Equal(expectedPriority, priority);
    }
}