using ContactsApp.Infrastructure.Repository;

namespace ContactsApp.Infrastructure.Transaction
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task SaveAsync();
    }
}
