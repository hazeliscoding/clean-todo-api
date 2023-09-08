using System.Configuration;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Context;
using TodoList.Domain.Abstractions;
using TodoList.Domain.TodoItems;
using TodoList.Infrastructure.Data;
using TodoList.Infrastructure.Repositories;

namespace TodoList.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = 
            configuration.GetConnectionString("DefaultConnection") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        services.AddTransient<IUnitOfWork, DapperUnitOfWork>(c => new DapperUnitOfWork(connectionString));

        services.AddSingleton(new MySqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyHandler());

        return services;
    }
}