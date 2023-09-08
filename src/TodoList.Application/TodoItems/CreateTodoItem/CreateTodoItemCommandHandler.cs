using MediatR;
using TodoList.Domain.Abstractions;
using TodoList.Domain.TodoItems;

namespace TodoList.Application.TodoItems.CreateTodoItem;

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly ITodoItemRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PrioritySuggestionService _priorityService;

    public CreateTodoItemCommandHandler(ITodoItemRepository repository, IUnitOfWork unitOfWork, PrioritySuggestionService priorityService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _priorityService = priorityService;
    }

    public async Task<int> Handle(CreateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var todoItem = new TodoItem(command.Title, command.DueDate, _priorityService);

        await _repository.AddAsync(todoItem);
        _unitOfWork.Commit();

        return todoItem.Id;
    }
}