using EventManagement.DataAccess.Utils;
using EventManagement.Service.Dtos.EventTickets;
using EventManagement.Service.Interfaces.EvenTickets;
using EventManagement.Service.Validators.Dtos.EventTickets;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.WebApi.Controllers
{
    [Route("api/event-tickets")]
    [ApiController]
    public class EventTicketsController : ControllerBase
    {
        private readonly IEventTicketService _service;
        private readonly int maxPageSize = 30;

        public EventTicketsController(IEventTicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("eventTicketId")]
        public async Task<IActionResult> GetByIdAsync(long eventTicketId)
            => Ok(await _service.GetByIdAsync(eventTicketId));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EventTicketCreateDto eventTicketDto)
        {
            var validator = new EventTicketCreateValidator();
            var result = validator.Validate(eventTicketDto);
            if (result.IsValid) return Ok(await _service.CreateAsync(eventTicketDto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("eventTicketId")]
        public async Task<IActionResult> UpdateAsync(long eventTicketId, [FromBody] EventTicketUpdateDto eventTicketUpdateDto)
        {
            var eventTicketValidator = new EventTicketUpdateValidator();
            var result = eventTicketValidator.Validate(eventTicketUpdateDto);
            if (result.IsValid) return Ok(await _service.UpdateAsync(eventTicketId, eventTicketUpdateDto));
            else return BadRequest(result.Errors);
        }

        [HttpDelete("eventTicketId")]
        public async Task<IActionResult> DeleteAsync(long eventTicketId)
            => Ok(await _service.DeleteAsync(eventTicketId));
    }
}