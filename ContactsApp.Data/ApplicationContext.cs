using ContactApp.Core.Entities;
using ContactsApp.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Counteragent> Counteragents { get; set; } = null!;

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CounteragentEntityTypeConfiguration());
        }
    }
}
