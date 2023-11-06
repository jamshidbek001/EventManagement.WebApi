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

        [HttpPost("register/verify")]
        public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyRegisterDto verifyRegisterDto)
        {
            var serviceResult =
                await _service.VerifyRegisterAsync(verifyRegisterDto.Email, verifyRegisterDto.Code);

            return Ok(new { serviceResult.Result, serviceResult.Token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            var loginValidator = new LoginValidator();
            var valResult = loginValidator.Validate(loginDto);
            if(valResult.IsValid == false) return BadRequest(valResult.Errors);

            var serviceResult = await _service.LoginAsync(loginDto);
            return Ok(new { serviceResult.Result, serviceResult.Token });
        }
    }
}