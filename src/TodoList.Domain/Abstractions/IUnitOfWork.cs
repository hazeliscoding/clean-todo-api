namespace TodoList.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    int Commit();
}
