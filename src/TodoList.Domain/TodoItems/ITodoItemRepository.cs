namespace TodoList.Domain.TodoItems;

public interface ITodoItemRepository
{
    Task<TodoItem> GetByIdAsync(int id);
    Task<List<TodoItem>> GetAllAsync();
    Task AddAsync(TodoItem item);
    Task UpdateAsync(TodoItem item);
    Task DeleteAsync(int id);
}
