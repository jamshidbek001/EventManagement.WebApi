using EventManagement.Service.Dtos.Events;
using EventManagement.Service.Interfaces.Events;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.WebApi.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            this._eventService = eventService;
        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            =>Ok(await _eventService.CountAsync());

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EventCreateDto eventDto)
            =>Ok(await _eventService.CreateAsync(eventDto));
    }
}