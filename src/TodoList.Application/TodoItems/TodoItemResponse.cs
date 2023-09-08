namespace TodoList.Application.TodoItems;

public class TodoItemResponse
{
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public string Priority { get; set; }
}