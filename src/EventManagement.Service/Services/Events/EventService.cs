using EventManagement.DataAccess.Interfaces.Events;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Events;
using EventManagement.Service.Common.Helpers;
using EventManagement.Service.Dtos.Events;
using EventManagement.Service.Interfaces.Common;
using EventManagement.Service.Interfaces.Events;

namespace EventManagement.Service.Services.Events;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IFileService _fileService;

    public EventService(
        IEventRepository eventRepository,
        IFileService fileService)
    {
        this._eventRepository = eventRepository;
        this._fileService = fileService;
    }

    public async Task<long> CountAsync()=> await _eventRepository.CountAsync();

    public async Task<bool> CreateAsync(EventCreateDto eventDto)
    {
        var organizerId = 1;

        Event events = new Event()
        {
            EventName = eventDto.EventName,
            DateTime = eventDto.DateTime,
            Location = eventDto.Location,
            Description = eventDto.Description,
            OrganizerId = organizerId,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };

        var result = await _eventRepository.CreateAsync(events);
        return result > 0;
    }

    public Task<bool> DeleteAsync(long eventId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Event>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<long> GetByIdAsync(long eventId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long eventId, EventCreateDto eventDto)
    {
        throw new NotImplementedException();
    }
}