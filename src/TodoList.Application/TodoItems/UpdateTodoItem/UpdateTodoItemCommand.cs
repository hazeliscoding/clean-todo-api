using MediatR;

namespace TodoList.Application.TodoItems.UpdateTodoItem;

public class UpdateTodoItemCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateOnly DueDate { get; set; }
    public bool? IsCompleted { get; set; }
}