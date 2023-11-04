using EventManagement.DataAccess.Utils;
using EventManagement.Service.Dtos.Comments;
using EventManagement.Service.Interfaces.Comments;
using EventManagement.Service.Validators.Dtos.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.WebApi.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly int maxPageSize = 30;

        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page,maxPageSize)));

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());

        [HttpGet("commentId")]
        public async Task<IActionResult> GetByIdAsync(long commentId)
            => Ok(await _service.GetByIdAsync(commentId));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CommentCreateDto dto)
        {
            var commentValidator = new CommentCreateValidator();
            var result = commentValidator.Validate(dto);
            if(result.IsValid) return Ok(await _service.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("commentId")]
        public async Task<IActionResult> UpdateAsync(long commentId, [FromBody] CommentUpdateDto dto)
        {
            var commentValidator = new CommentUpdateValidator();
            var result = commentValidator.Validate(dto);
            if(result.IsValid) return Ok(await _service.UpdateAsync(commentId, dto));
            else return BadRequest(result.Errors);
        }

        [HttpDelete("commentId")]
        public async Task<IActionResult> DeleteAsync(long commentId)
            => Ok(await _service.DeleteAsync(commentId));
    }
}