using MediatR;

namespace TodoList.Application.TodoItems.GetAllTodoItems;

public class GetAllTodoItemsQuery : IRequest<List<TodoItemResponse>>
{
}