using ContactApp.Core.Entities;
using ContactsApp.Data;
using ContactsApp.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Tests
{
    public class ContactsRepositotyTest
    {
        private ContactsRepository contactsRepository;

        private Contact testContact = null!;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("Test").Options;

            var context = new ApplicationContext(contextOptions);
            contactsRepository = new ContactsRepository(context);

            testContact = new Contact()
            {
                Email = "test@test.com",
                Name = "test",
                Lastname = "test",
                Patronymic = "test",
            };

            context.AddAsync(testContact);
        }

        [Test]
        public async Task FindAsync_ShouldFind_Test()
        {
            var actual = await contactsRepository.FindAsync(testContact.Id);

            Assert.IsNotNull(actual);
            Assert.That(testContact.Id, Is.EqualTo(actual.Id));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(999)]
        public async Task FindAsync_ShouldNotFind_Test(int id)
        {
            var actual = await contactsRepository.FindAsync(id);

            Assert.IsNull(actual);
        }

        [Test]
        public async Task AddAsync_ValidEntity_ShouldAdded_Test()
        {
            var contact = new Contact()
            {
                Email = "test@test.com",
                Name = "test",
                Lastname = "test",
                Patronymic = "test",
            };

            await contactsRepository.CreateAsync(contact);

            var actual = await contactsRepository.FindAsync(contact.Id);

            Assert.IsNotNull(actual);
        }


        [Test]
        public async Task UpdateAsync_ValidEntity_ShouldUpdated_Test()
        {
            var contact = new Contact()
            {
                Email = "email",
                Name = "test",
                Lastname = "test",
                Patronymic = "test",
            };

            DateTime expectedCreationDate = contact.CreationDate;

            await contactsRepository.CreateAsync(contact);

            string expected = "email1";
            contact.Email = expected;

            contactsRepository.Update(contact);

            var actual = (await contactsRepository.FindAsync(contact.Id));
            Assert.IsNotNull(actual);
            Assert.That(expected, Is.EqualTo(actual.Email));
        }
    }
}
