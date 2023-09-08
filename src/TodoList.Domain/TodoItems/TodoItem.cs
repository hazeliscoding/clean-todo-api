using TodoList.Domain.Abstractions;
using TodoList.Domain.TodoItems.Events;

namespace TodoList.Domain.TodoItems;

public class TodoItem : BaseEntity
{
    public string Title { get; private set; }
    public DateOnly DueDate { get; private set; }
    public bool IsCompleted { get; private set; }
    public string Priority { get; private set; }

    private TodoItem()
    {
        // This empty constructor is required for Dapper materialization
    }

    public TodoItem(string title, DateOnly dueDate, PrioritySuggestionService priorityService)
    {
        SetTitle(title);
        SetDueDate(dueDate);
        IsCompleted = false;
        SetPriority(priorityService);
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
        AddDomainEvent(new TodoItemCompletedEvent(this));
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        Title = title;
    }

    public void SetDueDate(DateOnly dueDate)
    {
        DueDate = dueDate;
    }

    private void SetPriority(PrioritySuggestionService priorityService)
    {
        Priority = priorityService.SuggestPriority(this);
    }
}
