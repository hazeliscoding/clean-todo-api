using TodoList.Domain.Abstractions;

namespace TodoList.Domain.TodoItems.Events;

public class TodoItemCompletedEvent : IDomainEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        TodoItem = item;
    }

    public TodoItem TodoItem { get; }
}
