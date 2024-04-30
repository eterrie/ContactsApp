using System;
using ContactApp.Core.Entities;
using ContactApp.Core.Exceptions;
using ContactsApp.Infrastructure.Helpers;
using ContactsApp.Infrastructure.Repository;
using ContactsApp.Infrastructure.Transaction;

namespace ContactsApp.Infrastructure.Services
{
    public class CounteragentsService : IAsyncDisposable
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICounteragentsRepository counteragentsRepository;
        private readonly ValidationService validationService;

        public CounteragentsService(ValidationService validationService, ICounteragentsRepository counteragentsRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.counteragentsRepository = counteragentsRepository;
            this.validationService = validationService;
        }

        public async Task<Response<Counteragent>> FindCounteragent(int id)
        {
            try
            {
                var counteragent = await counteragentsRepository.FindAsync(id);

                return new()
                {
                    Success = true,
                    Message = "Контрагент успешно найден",
                    Value = counteragent
                };
            }
            catch(ContactsAppException exception)
            {
                return new()
                {
                    Success = false,
                    Message = exception.Message
                };
            }
            catch(Exception exception)
            {
                return new()
                {
                    Success = false,
                    Message = "Не удалось найти контрагента",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async Task<Response<Counteragent[]>> ListCounteragents()
        {
            try
            {
                var value = await counteragentsRepository.ListCounteragentsAsync();
                return new()
                {
                    Success = true,
                    Message = "Контрагенты успешно получены",
                    Value = value
                };
            }
            catch (Exception exception)
            {
                return new()
                {
                    Success = false,
                    Message = "Не удалось получить список контрагентов",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async Task<Response> CreateCounteragent(Counteragent counteragent)
        {
            try
            {
                bool isValidated = validationService.ValidateStrings(counteragent.Name);

                if(!isValidated)
                {
                    throw new ValidationException("Название контрагента не было заполнено");
                }

                await counteragentsRepository.CreateAsync(counteragent);
                await unitOfWork.SaveAsync();

                return new()
                {
                    Success = true,
                    Message = "Контрагент успешно добавлен",
                };
            }
            catch(Exception exception)
            {
                return new()
                {
                    Success = false,
                    Message = "Не удалось создать контрагента",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async Task<Response> UpdateCounteragent(int counteragentId, Counteragent counteragent)
        {
            try
            {
                bool isValidated = validationService.ValidateStrings(counteragent.Name);

                if (!isValidated)
                {
                    throw new ValidationException("Название контрагента не было заполнено");
                }

                var foundCounteragent = await counteragentsRepository.FindAsync(counteragentId);

                if(foundCounteragent == null)
                {
                    throw new NotFoundException("Контрагент не найден");
                }

                foundCounteragent.Name = counteragent.Name;

                counteragentsRepository.Update(foundCounteragent);
                await unitOfWork.SaveAsync();

                return new()
                {
                    Success = true,
                    Message = "Контрагент успешно изменен",
                };
            }
            catch(ContactsAppException exception)
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
                    Message = "Не удалось создать контрагента",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async Task<Response> RemoveCounteragent(int counteragentId)
        {
            try
            {
                await counteragentsRepository.RemoveAsync(counteragentId);
                await unitOfWork.SaveAsync();

                return new()
                {
                    Success = true,
                    Message = "Контрагент успешно удален",
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
                    Message = "Не удалось удалить контрагента",
                    InternalErrorMessages = [exception.Message]
                };
            }
        }

        public async ValueTask DisposeAsync()
        {
            await unitOfWork.DisposeAsync();
            await counteragentsRepository.DisposeAsync();
        }
    }
}
