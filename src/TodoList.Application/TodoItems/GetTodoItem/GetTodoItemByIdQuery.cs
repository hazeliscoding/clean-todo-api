using MediatR;

namespace TodoList.Application.TodoItems.GetTodoItem;

public class GetTodoItemByIdQuery : IRequest<TodoItemResponse>
{
    public int Id { get; set; }
}