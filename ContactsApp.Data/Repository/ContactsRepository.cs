using ContactApp.Core.Entities;
using ContactApp.Core.Exceptions;
using ContactsApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Data.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ApplicationContext applicationContext;

        public ContactsRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task CreateAsync(Contact entity)
        {
            await applicationContext.AddAsync(entity);
        }

        public async Task<Contact?> FindAsync(int id)
        {
            var contact = await applicationContext.Contacts.FindAsync(id);

            if(contact == null)
            {
                return null;
            }

            await applicationContext.Entry(contact)
                .Reference(contact => contact.Counteragent)
                .LoadAsync();

            return contact;
        }

        public async Task<Contact[]> ListContactsAsync()
        {
            var contacts = await applicationContext.Contacts.ToArrayAsync();

            return contacts;
        }

        public async Task<Contact[]> ListContactsAtCounteragentAsync(int counteragentId)
        {
            var counteragent = await applicationContext.Counteragents
                .FirstOrDefaultAsync(counteragent => counteragent.Id == counteragentId);

            if(counteragent == null)
            {
                throw new NotFoundException("Контрагент не найден");
            }

            await applicationContext.Entry(counteragent)
                .Collection(counteragent => counteragent.Contacts)
                .LoadAsync();

            return counteragent.Contacts.ToArray();
        }

        public async Task RemoveAsync(int id)
        {
            var contact = await applicationContext.Contacts.FindAsync(id);

            if(contact == null)
            {
                throw new NotFoundException("Контакт не был найден");
            }

            applicationContext.Contacts.Remove(contact);
        }

        public void Update(Contact entity)
        {
            applicationContext.Contacts.Update(entity);
            applicationContext.Contacts.Where(counteragent => counteragent.Id == entity.Id).ExecuteUpdate(s => s.SetProperty(c => c.UpdateDate, DateTime.UtcNow));
        }

        public async ValueTask DisposeAsync()
        {
            await applicationContext.DisposeAsync();
        }
    }
}
