namespace ContactsApp.Infrastructure.Repository
{
    public interface IAsyncRepository<T>: IAsyncDisposable where T: class
    {
        Task CreateAsync(T entity);
        Task<T?> FindAsync(int id);
        Task RemoveAsync(int id);
        void Update(T entity);
    }
}
