using EventManagement.DataAccess.Interfaces.EventRegistrations;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.EventRegistrations;
using EventManagement.Domain.Exceptions.EventRegistrations;
using EventManagement.Service.Common.Helpers;
using EventManagement.Service.Dtos.EventRegistrations;
using EventManagement.Service.Interfaces.EventRegistrations;

namespace EventManagement.Service.Services.EventRegistrations
{
    public class EventRegistrationService : IEventRegistrationService
    {
        private readonly IEventRegistrationRepository _repository;

        public EventRegistrationService(IEventRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> CountAsync() => await _repository.CountAsync();

        public async Task<bool> CreateAsync(EventRegistrationCreateDto dto)
        {
            EventRegistration eventRegistration = new EventRegistration()
            {
                EventId = dto.EventId,
                AttendeeId = dto.AttendeeId,
                NumberOfTickets = dto.NumberOfTickets,
                TotalPrice = dto.TotalPrice,
                RegistrationDate = DateTime.Now,
                PaymentStatus = dto.PaymentStatus,
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime()
            };

            var result = await _repository.CreateAsync(eventRegistration);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long eventRegistrationId)
        {
            var eventRegistration = await _repository.GetByIdAsync(eventRegistrationId);
            if (eventRegistration is null) throw new EventRegistrationNotFoundException();
            var result = await _repository.DeleteAsync(eventRegistrationId);
            return result > 0;
        }

        public async Task<IList<EventRegistration>> GetAllAsync(PaginationParams @params)
        {
            var eventRegistrations = await _repository.GetAllAsync(@params);
            return eventRegistrations;
        }

        public async Task<EventRegistration> GetByIdAsync(long eventRegistrationId)
        {
            var eventRegistration = await _repository.GetByIdAsync(eventRegistrationId);
            if (eventRegistration is null) throw new EventRegistrationNotFoundException();
            else return eventRegistration;
        }

        public async Task<bool> UpdateAsync(long eventRegistrationId, EventRegistrationUpdateDto dto)
        {
            var eventRegistration = await _repository.GetByIdAsync(eventRegistrationId);
            if (eventRegistration is null) throw new EventRegistrationNotFoundException();
            eventRegistration.EventId = dto.EventId;
            eventRegistration.AttendeeId = dto.AttendeeId;
            eventRegistration.TotalPrice = dto.TotalPrice;
            eventRegistration.NumberOfTickets = dto.NumberOfTickets;
            eventRegistration.UpdatedAt = TimeHelper.GetDateTime();
            var dbResult = await _repository.UpdateAsync(eventRegistrationId, eventRegistration);
            return dbResult > 0;
        }
    }
}