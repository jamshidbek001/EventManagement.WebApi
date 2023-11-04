using EventManagement.DataAccess.Utils;
using EventManagement.Service.Dtos.EventRegistrations;
using EventManagement.Service.Interfaces.EventRegistrations;
using EventManagement.Service.Validators.Dtos.EventRegistrations;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.WebApi.Controllers
{
    [Route("api/event-registrations")]
    [ApiController]
    public class EventRegistrationsController : ControllerBase
    {
        private readonly IEventRegistrationService _service;
        private readonly int maxPageSize = 30;

        public EventRegistrationsController(IEventRegistrationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());

        [HttpGet("eventRegistrationId")]
        public async Task<IActionResult> GetByIdAsync(long eventRegistrationId)
            => Ok(await _service.GetByIdAsync(eventRegistrationId));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EventRegistrationCreateDto dto)
        {
            var eventValidator = new EventRegistrationCreateValidator();
            var result = eventValidator.Validate(dto);
            if(result.IsValid) return Ok(await _service.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("eventRegistrationId")]
        public async Task<IActionResult> UpdateAsync(long eventRegistrationId,[FromBody] EventRegistrationUpdateDto dto)
        {
            var eventValidator = new EventRegistrationUpdateValidator();
            var result = eventValidator.Validate(dto);
            if(result.IsValid) return Ok(await _service.UpdateAsync(eventRegistrationId, dto));
            else return BadRequest(result.Errors);
        }

        [HttpDelete("eventRegistrationId")]
        public async Task<IActionResult> DeleteAsync(long eventRegistrationId)
            => Ok(await _service.DeleteAsync(eventRegistrationId));
    }
}