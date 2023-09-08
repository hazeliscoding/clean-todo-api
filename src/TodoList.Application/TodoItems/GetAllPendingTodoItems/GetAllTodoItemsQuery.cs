using MediatR;

namespace TodoList.Application.TodoItems.GetAllPendingTodoItems;

public class GetAllTodoItemsQuery : IRequest<List<TodoItemResponse>>
{
}