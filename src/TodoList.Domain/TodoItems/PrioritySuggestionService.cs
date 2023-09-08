namespace TodoList.Domain.TodoItems;

public class PrioritySuggestionService
{
    public string SuggestPriority(TodoItem todoItem)
    {
        // Convert DateOnly to DateTime (midnight of that date in UTC)
        DateTime dueDateTime = todoItem.DueDate.ToDateTime(TimeOnly.FromDateTime(DateTime.UtcNow));

        // Calculate time left
        TimeSpan timeLeft = dueDateTime - DateTime.UtcNow;


        if (timeLeft.TotalDays <= 1)
        {
            return "High";
        }
        else if (timeLeft.TotalDays <= 3)
        {
            return "Medium";
        }
        else
        {
            return "Low";
        }
    }
}
