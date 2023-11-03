using EventManagement.DataAccess.Interfaces.EventTickets;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.EventTickets;
using EventManagement.Domain.Exceptions.EventTickets;
using EventManagement.Service.Common.Helpers;
using EventManagement.Service.Dtos.EventTickets;
using EventManagement.Service.Interfaces.EvenTickets;

namespace EventManagement.Service.Services.EventTickets
{
    public class EventTicketService : IEventTicketService
    {
        private readonly IEventTicketRepository _repository;

        public EventTicketService(IEventTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> CountAsync() => await _repository.CountAsync();

        public async Task<bool> CreateAsync(EventTicketCreateDto eventTicketDto)
        {
            EventTicket eventTicket = new EventTicket()
            {
                EventId = eventTicketDto.EventId,
                TicketName = eventTicketDto.TicketName,
                QuantityAvailable = eventTicketDto.QuantityAvailable,
                Price = eventTicketDto.Price,
                SaleStartDate = DateTime.Now,
                SaleEndDate = DateTime.Now.AddHours(72),
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime()
            };

            var result = await _repository.CreateAsync(eventTicket);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long eventTicketId)
        {
            var eventTicket = await _repository.GetByIdAsync(eventTicketId);
            if (eventTicket is null) throw new EventTicketNotFoundException();
            var dbResult = await _repository.DeleteAsync(eventTicketId);
            return dbResult > 0;
        }

        public async Task<IList<EventTicket>> GetAllAsync(PaginationParams @params)
        {
            var eventTickets = await _repository.GetAllAsync(@params);
            return eventTickets;
        }

        public async Task<EventTicket> GetByIdAsync(long eventTicketId)
        {
            var eventTicket = await _repository.GetByIdAsync(eventTicketId);
            if (eventTicket is null) throw new EventTicketNotFoundException();
            else return eventTicket;
        }

        public async Task<bool> UpdateAsync(long eventTicketId, EventTicketUpdateDto updateDto)
        {
            var eventTicket = await _repository.GetByIdAsync(eventTicketId);
            if (eventTicket is null) throw new EventTicketNotFoundException();
            eventTicket.EventId = updateDto.EventId;
            eventTicket.TicketName = updateDto.TicketName;
            eventTicket.Price = updateDto.Price;
            eventTicket.QuantityAvailable = updateDto.QuantityAvailable;
            eventTicket.SaleStartDate = updateDto.SaleStartDate;
            eventTicket.SaleEndDate = updateDto.SaleEndDate;
            eventTicket.UpdatedAt = TimeHelper.GetDateTime();
            var result = await _repository.UpdateAsync(eventTicketId, eventTicket);
            return result > 0;
        }
    }
}