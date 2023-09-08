using MediatR;
using TodoList.Domain.TodoItems;

namespace TodoList.Application.TodoItems.GetAllTodoItems;

public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, List<TodoItemResponse>>
{
    private readonly ITodoItemRepository _repository;

    public GetAllTodoItemsQueryHandler(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TodoItemResponse>> Handle(GetAllTodoItemsQuery query, CancellationToken cancellationToken)
    {
        var todoItems = await _repository.GetAllAsync();

        return todoItems.Select(todoItem => new TodoItemResponse
        {
            Id = todoItem.Id,
            Title = todoItem.Title,
            DueDate = todoItem.DueDate,
            IsCompleted = todoItem.IsCompleted,
            Priority = todoItem.Priority
        }).ToList();
    }
}