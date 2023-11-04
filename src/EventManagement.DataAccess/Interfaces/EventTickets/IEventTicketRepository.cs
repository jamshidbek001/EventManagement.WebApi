using EventManagement.DataAccess.Common.Interfaces;
using EventManagement.Domain.Entities.EventTickets;

namespace EventManagement.DataAccess.Interfaces.EventTickets;

public interface IEventTicketRepository :
    IRepository<EventTicket, EventTicket>, IGetAll<EventTicket>
{ }