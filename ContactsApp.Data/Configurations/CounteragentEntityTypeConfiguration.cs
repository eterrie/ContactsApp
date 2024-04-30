using ContactApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsApp.Data.Configurations
{
    public class CounteragentEntityTypeConfiguration : IEntityTypeConfiguration<Counteragent>
    {
        public void Configure(EntityTypeBuilder<Counteragent> builder)
        {
            builder.HasIndex(counteragent => counteragent.Name)
                .IsUnique();

            builder
                .HasMany(counteragent => counteragent.Contacts)
                .WithOne(contact => contact.Counteragent)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(counteragent => counteragent.Name)
                .IsRequired();

            builder.Property(counteragent => counteragent.CreationDate)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            builder.Property(counteragent => counteragent.UpdateDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("now()");
        }
    }
}
