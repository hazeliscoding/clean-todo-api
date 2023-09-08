using MediatR;
using TodoList.Domain.Abstractions;
using TodoList.Domain.TodoItems;

namespace TodoList.Application.TodoItems.DeleteTodoItem;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, bool>
{
    private readonly ITodoItemRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTodoItemCommandHandler(ITodoItemRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteTodoItemCommand command, CancellationToken cancellationToken)
    {
        var todoItem = await _repository.GetByIdAsync(command.Id);
        if (todoItem == null) return false;

        await _repository.DeleteAsync(command.Id);
        _unitOfWork.Commit();

        return true;
    }
}