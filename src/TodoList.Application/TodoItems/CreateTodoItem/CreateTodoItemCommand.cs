using MediatR;

namespace TodoList.Application.TodoItems.CreateTodoItem;

public class CreateTodoItemCommand : IRequest<int>
{
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
}
