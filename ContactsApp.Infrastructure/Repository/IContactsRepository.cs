using ContactApp.Core.Entities;

namespace ContactsApp.Infrastructure.Repository
{
    public interface IContactsRepository : IAsyncRepository<Contact>
    {
        Task<Contact[]> ListContactsAtCounteragentAsync(int counteragentId);
        Task<Contact[]> ListContactsAsync();
    }
}
