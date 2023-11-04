using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.EventRegistrations;
using EventManagement.Service.Dtos.EventRegistrations;

namespace EventManagement.Service.Interfaces.EventRegistrations
{
    public interface IEventRegistrationService
    {
        public Task<long> CountAsync();

        public Task<bool> CreateAsync(EventRegistrationCreateDto dto);

        public Task<IList<EventRegistration>> GetAllAsync(PaginationParams @params);

        public Task<bool> DeleteAsync(long eventRegistrationId);

        public Task<EventRegistration> GetByIdAsync(long eventRegistrationId);

        public Task<bool> UpdateAsync(long eventRegistrationId, EventRegistrationUpdateDto dto);
    }
}