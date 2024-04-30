using ContactsApp.Infrastructure.Transaction;

namespace ContactsApp.Data.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly ApplicationContext applicationContext;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async ValueTask DisposeAsync()
        {
            await this.applicationContext.DisposeAsync();
        }

        public async Task SaveAsync()
        {
            await applicationContext.SaveChangesAsync();
        }
    }
}
