using EventManagement.Service.Dtos.Auth;
using EventManagement.Service.Interfaces.Auth;
using EventManagement.Service.Validators.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthContoller : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthContoller(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto dto)
        {
            var validator = new RegisterValidator();
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                var serviceResult = await _service.RegisterAsync(dto);
                return Ok(new { serviceResult.Result, serviceResult.cachedMinutes });
            }
            else return BadRequest(result.Errors);
        }
    }
}
