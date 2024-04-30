using ContactApp.Core.Entities;

namespace ContactsApp.Infrastructure.Repository
{
    public interface ICounteragentsRepository : IAsyncRepository<Counteragent>
    {
        Task<Counteragent[]> ListCounteragentsAsync();
        Task<Counteragent?> FindWithLoadedContactsAsync(int id);
    }
}
