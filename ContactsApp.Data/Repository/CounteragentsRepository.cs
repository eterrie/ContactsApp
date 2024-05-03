using System;
using ContactApp.Core.Entities;
using ContactApp.Core.Exceptions;
using ContactsApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Data.Repository
{
    public class CounteragentsRepository : ICounteragentsRepository
    {
        private readonly ApplicationContext applicationContext;

        public CounteragentsRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task CreateAsync(Counteragent entity)
        {
            await applicationContext.Counteragents.AddAsync(entity);
        }

        public async Task<Counteragent?> FindAsync(int id)
        {
            return await applicationContext.Counteragents.FindAsync(id);
        }

        public async Task<Counteragent?> FindWithLoadedContactsAsync(int id)
        {
            var counteragent = await applicationContext.Counteragents.FindAsync(id);

            if(counteragent == null)
            {
                throw new NotFoundException("Контрагент не найден");
            }

            await applicationContext.Entry(counteragent)
                .Collection(counteragent => counteragent.Contacts)
                .LoadAsync();

            return counteragent;
        }

        public async Task<Counteragent[]> ListCounteragentsAsync()
        {
            return await applicationContext.Counteragents.AsNoTracking().ToArrayAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var counteragent = await applicationContext.Counteragents.FindAsync(id);

            if(counteragent == null)
            {
                throw new NotFoundException("Контрагент не был найден");
            }

            applicationContext.Counteragents.Remove(counteragent);
        }

        public void Update(Counteragent entity)
        {
            applicationContext.Counteragents.Update(entity);
            applicationContext.Counteragents.Where(counteragent => counteragent.Id == entity.Id).ExecuteUpdate(s => s.SetProperty(c => c.UpdateDate, DateTime.UtcNow));
        }

        public async ValueTask DisposeAsync()
        {
            await applicationContext.DisposeAsync();
        }
    }
}
