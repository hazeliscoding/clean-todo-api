using MediatR;
using TodoList.Domain.TodoItems;

namespace TodoList.Application.TodoItems.GetTodoItem;

public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItemResponse>
{
    private readonly ITodoItemRepository _repository;

    public GetTodoItemByIdQueryHandler(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoItemResponse> Handle(GetTodoItemByIdQuery query, CancellationToken cancellationToken)
    {
        var todoItem = await _repository.GetByIdAsync(query.Id);
        if (todoItem == null) return null;

        return new TodoItemResponse()
        {
            Id = todoItem.Id,
            Title = todoItem.Title,
            DueDate = todoItem.DueDate,
            IsCompleted = todoItem.IsCompleted,
            Priority = todoItem.Priority // Assuming Priority is a public property on TodoItem
        };
    }
}