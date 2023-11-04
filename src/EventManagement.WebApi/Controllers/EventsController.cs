using EventManagement.DataAccess.Utils;
using EventManagement.Service.Dtos.Events;
using EventManagement.Service.Interfaces.Events;
using EventManagement.Service.Validators.Dtos.Events;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.WebApi.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly int maxPageSize = 30;

        public EventsController(IEventService eventService)
        {
            this._eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _eventService.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetByIdAsync(long eventId)
            => Ok(await _eventService.GetByIdAsync(eventId));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _eventService.CountAsync());

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] EventCreateDto eventDto)
        {
            var eventValidator = new EventCreateValidator();
            var result = eventValidator.Validate(eventDto);
            if (result.IsValid) return Ok(await _eventService.CreateAsync(eventDto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("eventId")]
        public async Task<IActionResult> UpdateAsync(long eventId, [FromForm] EventUpdateDto eventDto)
        {
            var updateValidator = new EventUpdateValidator();
            var result = updateValidator.Validate(eventDto);
            if (result.IsValid) return Ok(await _eventService.UpdateAsync(eventId, eventDto));
            else return BadRequest(result.Errors);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteAsync(long eventId)
            => Ok(await _eventService.DeleteAsync(eventId));
    }
}