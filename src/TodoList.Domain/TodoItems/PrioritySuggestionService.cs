namespace TodoList.Domain.TodoItems;

public class PrioritySuggestionService
{
    public string SuggestPriority(TodoItem todoItem)
    {
        var timeLeft = todoItem.DueDate - DateTime.UtcNow;

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
