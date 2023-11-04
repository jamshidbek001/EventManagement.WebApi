using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Comments;
using EventManagement.Domain.Entities.Events;
using EventManagement.Service.Dtos.Comments;
using EventManagement.Service.Dtos.Events;

namespace EventManagement.Service.Interfaces.Comments
{
    public interface ICommentService
    {
        public Task<bool> CreateAsync(CommentCreateDto commentDto);

        public Task<bool> DeleteAsync(long commentId);

        public Task<long> CountAsync();

        public Task<IList<Comment>> GetAllAsync(PaginationParams @params);

        public Task<Comment> GetByIdAsync(long commentId);

        public Task<bool> UpdateAsync(long commentId, CommentUpdateDto commentDto);
    }
}