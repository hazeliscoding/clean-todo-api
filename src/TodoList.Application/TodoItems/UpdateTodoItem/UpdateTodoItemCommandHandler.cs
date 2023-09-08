using MediatR;
using TodoList.Domain.Abstractions;
using TodoList.Domain.TodoItems;

namespace TodoList.Application.TodoItems.UpdateTodoItem;

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, bool>
{
    private readonly ITodoItemRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PrioritySuggestionService _priorityService;

    public UpdateTodoItemCommandHandler(ITodoItemRepository repository, IUnitOfWork unitOfWork, PrioritySuggestionService priorityService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _priorityService = priorityService;
    }

    public async Task<bool> Handle(UpdateTodoItemCommand command, CancellationToken cancellationToken)
    {
        var todoItem = await _repository.GetByIdAsync(command.Id);
        if (todoItem == null) return false;

        todoItem.SetTitle(command.Title);
        todoItem.SetDueDate(command.DueDate);
        if (command.IsCompleted.HasValue && command.IsCompleted.Value)
        {
            todoItem.MarkAsCompleted();
        }

        await _repository.UpdateAsync(todoItem);
        _unitOfWork.Commit();

        return true;
    }
}
