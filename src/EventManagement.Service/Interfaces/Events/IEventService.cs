using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Events;
using EventManagement.Service.Dtos.Events;

namespace EventManagement.Service.Interfaces.Events
{
    public interface IEventService
    {
        public Task<bool> CreateAsync(EventCreateDto eventDto);

        public Task<bool> DeleteAsync(long eventId);

        public Task<long> CountAsync();

        public Task<IList<Event>> GetAllAsync(PaginationParams @params);

        public Task<Event> GetByIdAsync(long eventId);

        public Task<bool> UpdateAsync(long eventId, EventUpdateDto eventDto);
    }
}