using EventManagement.DataAccess.Utils;
using EventManagement.Service.Dtos.Notifications;
using EventManagement.Service.Interfaces.Notifications;
using EventManagement.Service.Validators.Dtos.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.WebApi.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _service;
        private readonly int maxPageSize = 30;

        public NotificationsController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());

        [HttpGet("notificationId")]
        public async Task<IActionResult> GetByIdAsync(long notificationId)
            => Ok(await _service.GetByIdAsync(notificationId));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] NotificationCreateDto dto)
        {
            var notificationValidator = new NotificationCreateValidator();
            var result = notificationValidator.Validate(dto);
            if (result.IsValid) return Ok(await _service.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("notificationId")]
        public async Task<IActionResult> UpdateAsync(long notificationId, [FromBody] NotificationUpdateDto dto)
        {
            var notificationValidator = new NotificationUpdateValidator();
            var result = notificationValidator.Validate(dto);
            if (result.IsValid) return Ok(await _service.UpdateAsync(notificationId, dto));
            else return BadRequest(result.Errors);
        }

        [HttpDelete("notificationId")]
        public async Task<IActionResult> DeleteAsync(long notificationId)
            => Ok(await _service.DeleteAsync(notificationId));
    }
}