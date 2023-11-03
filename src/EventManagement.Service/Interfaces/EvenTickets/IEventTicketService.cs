using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.EventTickets;
using EventManagement.Service.Dtos.EventTickets;

namespace EventManagement.Service.Interfaces.EvenTickets;

public interface IEventTicketService
{
    public Task<long> CountAsync();

    public Task<bool> CreateAsync(EventTicketCreateDto eventTicketDto);

    public Task<bool> DeleteAsync(long eventTicketId);

    public Task<IList<EventTicket>> GetAllAsync(PaginationParams @params);

    public Task<EventTicket> GetByIdAsync(long eventTicketId);

    public Task<bool> UpdateAsync(long eventTicketId, EventTicketUpdateDto updateDto);
}