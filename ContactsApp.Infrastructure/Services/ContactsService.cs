using ContactApp.Core.Entities;
using ContactApp.Core.Exceptions;
using ContactsApp.Infrastructure.Helpers;
using ContactsApp.Infrastructure.Repository;
using ContactsApp.Infrastructure.Transaction;

namespace ContactsApp.Infrastructure.Services
{
    public class ContactsService : IAsyncDisposable
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ValidationService validationService;
        private readonly IContactsRepository contactsRepository;
        private readonly ICounteragentsRepository counteragentsRepository;

        public ContactsService(IUnitOfWork unitOfWork, IContactsRepository contactsRepository, ValidationService validationService, ICounteragentsRepository counteragentsRepository)
        {
            this.unitOfWork = unitOfWork;
            this.contactsRepository = contactsRepository;
            this.validationService = validationService;
            this.counteragentsRepository = counteragentsRepository;
        }

        public async Task<Response<Contact?>> FindContact(int contactId)
        {
            try
            {
                var contact = await contactsRepository.FindAsync(contactId);

                return new()
                {
                    Success = true,
                    Message = "Контрагент успешно найден",
                    Value = contact
                };
            }
            catch (ContactsAppException exception)
            {
                return new()
                {
                    Success = false,
                    Message = exception.Message
                };
            }
            catch (Exception exception)
            {
                return new()
                {
                    Success = false,
                    Message = "Не удалось найти контрагента",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async Task<Response> CreateContact(Contact contact, int counteragentId)
        {
            try
            {
                bool isValidated = validationService.ValidateStrings(contact.Email, contact.Name, contact.Lastname, contact.Patronymic);

                if(!isValidated)
                {
                    throw new ValidationException("Не все поля контакта были заполнены");
                }

                var counteragent = await counteragentsRepository.FindAsync(counteragentId);

                if(counteragent == null)
                {
                    throw new NotFoundException("Контрагент не найден");
                }

                contact.Counteragent = counteragent;

                await contactsRepository.CreateAsync(contact);
                await unitOfWork.SaveAsync();

                return new()
                {
                    Success = true,
                    Message = "Контакт успешно создан",
                };
            }
            catch (ContactsAppException exception)
            {
                return new()
                {
                    Success = false,
                    Message = exception.Message
                };
            }
            catch (Exception exception)
            {
                return new()
                {
                    Success = false,
                    Message = "Не удалось найти контрагента",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async Task<Response<Contact[]>> ListContactsAtCounteragent(int counteragentId)
        {
            try
            {
                var contacts = await contactsRepository.ListContactsAtCounteragentAsync(counteragentId);

                return new()
                {
                    Success = true,
                    Message = "Контрагенты успешно получены",
                    Value = contacts
                };
            }
            catch (ContactsAppException exception)
            {
                return new()
                {
                    Success = false,
                    Message = exception.Message
                };
            }
            catch (Exception exception)
            {
                return new()
                {
                    Success = false,
                    Message = "Не удалось получить контрагентов",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async Task<Response<Contact[]>> ListContacts()
        {
            try
            {
                var contacts = await contactsRepository.ListContactsAsync();

                return new()
                {
                    Success = true,
                    Message = "Контрагенты успешно получены",
                    Value = contacts
                };
            }
            catch (ContactsAppException exception)
            {
                return new()
                {
                    Success = false,
                    Message = exception.Message
                };
            }
            catch (Exception exception)
            {
                return new()
                {
                    Success = false,
                    Message = "Не удалось получить контрагентов",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async Task<Response> UpdateContact(int contactId, int counteragentId, Contact contact)
        {
            try
            {
                bool isValidated = validationService.ValidateStrings(contact.Email, contact.Name, contact.Lastname, contact.Patronymic);

                if (!isValidated)
                {
                    throw new ValidationException("Не все поля контакта были заполнены");
                }

                var counteragent = await counteragentsRepository.FindAsync(counteragentId);

                if (counteragent == null)
                {
                    throw new NotFoundException("Контрагент не найден");
                }

                var foundContact = await contactsRepository.FindAsync(contactId);

                if(foundContact == null)
                {
                    throw new NotFoundException("Контакт не найден");
                }

                foundContact.Email = contact.Email;
                foundContact.Name = contact.Name;
                foundContact.Lastname = contact.Lastname;
                foundContact.Patronymic = contact.Patronymic;

                foundContact.Counteragent = counteragent;

                contactsRepository.Update(foundContact);
                await unitOfWork.SaveAsync();

                return new()
                {
                    Success = true,
                    Message = "Контакт успешно изменен",
                };
            }
            catch (ContactsAppException exception)
            {
                return new()
                {
                    Success = false,
                    Message = exception.Message
                };
            }
            catch (Exception exception)
            {
                return new()
                {
                    Success = false,
                    Message = "Не удалось найти контрагента",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async Task<Response> RemoveContact(int contactId)
        {
            try
            {
                await contactsRepository.RemoveAsync(contactId);
                await unitOfWork.SaveAsync();

                return new()
                {
                    Success = true,
                    Message = "Контакт успешно удален",
                };
            }
            catch (ContactsAppException exception)
            {
                return new()
                {
                    Success = false,
                    Message = exception.Message,
                    InternalErrorMessages = [exception.Message]
                };
            }
            catch (Exception exception)
            {
                return new()
                {
                    Success = false,
                    Message = "Не удалось удалить контакт",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async ValueTask DisposeAsync()
        {
            await unitOfWork.DisposeAsync();
            await contactsRepository.DisposeAsync();
        }
    }
}
