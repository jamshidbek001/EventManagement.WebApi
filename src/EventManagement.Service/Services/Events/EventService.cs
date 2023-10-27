using EventManagement.DataAccess.Interfaces.Events;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Events;
using EventManagement.Domain.Exceptions.Events;
using EventManagement.Service.Common.Helpers;
using EventManagement.Service.Dtos.Events;
using EventManagement.Service.Interfaces.Events;

namespace EventManagement.Service.Services.Events;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        this._eventRepository = eventRepository;
    }

    public async Task<long> CountAsync()=> await _eventRepository.CountAsync();

    public async Task<bool> CreateAsync(EventCreateDto eventDto)
    {
        Event @event = new Event()
        {
            EventName = eventDto.EventName,
            DateTime = eventDto.DateTime,
            Location = eventDto.Location,
            Description = eventDto.Description,
            OrganizerId = 1,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };

        var result = await _eventRepository.CreateAsync(@event);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long eventId)
    {
        var events = await _eventRepository.GetByIdAsync(eventId);
        if(events is null) throw new EventNotFoundException();
        var dbResult = await _eventRepository.DeleteAsync(eventId);
        return dbResult > 0;
    }

    public async Task<IList<Event>> GetAllAsync(PaginationParams @params)
    {
        var events = await _eventRepository.GetAllAsync(@params);
        return events;
    }

    public async Task<Event> GetByIdAsync(long eventId)
    {
        var events = await _eventRepository.GetByIdAsync(eventId);
        if (events is null) throw new EventNotFoundException();
        else return events;
    }

    public async Task<bool> UpdateAsync(long eventId, EventUpdateDto eventDto)
    {
        var events = await _eventRepository.GetByIdAsync(eventId);
        if (events is null) throw new EventNotFoundException();
        events.EventName = eventDto.EventName;
        events.DateTime = eventDto.DateTime;
        events.Location = eventDto.Location;
        events.Description = eventDto.Description;
        events.OrganizerId = 1;
        events.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _eventRepository.UpdateAsync(eventId, events);
        return dbResult > 0;
    }
}