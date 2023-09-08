using System.Reflection;
using TodoList.Application.Context;
using TodoList.Domain.Abstractions;
using TodoList.Infrastructure.Data;

namespace TodoList.ArchitectureTests;

public class BaseTest
{
    protected static Assembly ApplicationAssembly => typeof(DapperUnitOfWork).Assembly;
    protected static Assembly DomainAssembly => typeof(BaseEntity).Assembly;
    protected static Assembly InfrastructureAssembly => typeof(MySqlConnectionFactory).Assembly;
}