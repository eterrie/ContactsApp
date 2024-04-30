using ContactApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactsApp.Data.Configurations
{
    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasIndex(contact => contact.Email)
                .IsUnique();

            builder
                .HasOne(contact => contact.Counteragent)
                .WithMany(counteragent => counteragent.Contacts)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(contact => contact.Name)
                .IsRequired();

            builder.Property(contact => contact.Lastname)
                .IsRequired();

            builder.Property(contact => contact.Patronymic)
                .IsRequired();

            builder.Property(contact => contact.Email)
                .IsRequired();

            builder.Property(contact => contact.CreationDate);

            builder.Property(contact => contact.CreationDate)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnAdd();

            builder.Property(contact => contact.UpdateDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
