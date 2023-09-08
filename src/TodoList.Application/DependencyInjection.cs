using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Context;
using TodoList.Domain.Abstractions;
using TodoList.Domain.TodoItems;

namespace TodoList.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add MediatR with handlers from the Application assembly
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        // Register UoW, and other services
        // services.AddTransient<IUnitOfWork, DapperUnitOfWork>();
        services.AddTransient<PrioritySuggestionService>();

        return services;
    }
}