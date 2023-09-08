using MediatR;

namespace TodoList.Application.TodoItems.CreateTodoItem;

public class CreateTodoItemCommand : IRequest<int>
{
    public string Title { get; set; }
    public DateOnly DueDate { get; set; }
}
