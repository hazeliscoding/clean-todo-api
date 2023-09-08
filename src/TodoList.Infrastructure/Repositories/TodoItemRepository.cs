using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Repositories;

using Dapper;
using System.Data;
using TodoList.Domain.TodoItems;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly IDbConnection _connection;

    public TodoItemRepository(MySqlConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
    }

    public async Task<TodoItem> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM TodoItems WHERE Id = @Id";
        return await _connection.QuerySingleOrDefaultAsync<TodoItem>(sql, new { Id = id });
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        const string sql = "SELECT * FROM TodoItems";
        var todoItems = await _connection.QueryAsync<TodoItem>(sql);
        return todoItems.ToList();
    }

    public async Task AddAsync(TodoItem item)
    {
        const string sql = "INSERT INTO TodoItems (Title, DueDate, IsCompleted, Priority) VALUES (@Title, @DueDate, @IsCompleted, @Priority)";
        await _connection.ExecuteAsync(sql, item);
    }

    public async Task UpdateAsync(TodoItem item)
    {
        const string sql = "UPDATE TodoItems SET Title = @Title, DueDate = @DueDate, IsCompleted = @IsCompleted, Priority = @Priority WHERE Id = @Id";
        await _connection.ExecuteAsync(sql, item);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = "DELETE FROM TodoItems WHERE Id = @Id";
        await _connection.ExecuteAsync(sql, new { Id = id });
    }
}
