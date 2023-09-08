using MediatR;

namespace TodoList.Application.TodoItems.DeleteTodoItem;

public class DeleteTodoItemCommand : IRequest<bool>
{
    public int Id { get; set; }
}