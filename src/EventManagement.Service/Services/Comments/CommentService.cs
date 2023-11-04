using EventManagement.DataAccess.Interfaces.Comments;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Comments;
using EventManagement.Domain.Exceptions.Comments;
using EventManagement.Service.Common.Helpers;
using EventManagement.Service.Dtos.Comments;
using EventManagement.Service.Interfaces.Comments;

namespace EventManagement.Service.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> CountAsync() => await _repository.CountAsync();

        public async Task<bool> CreateAsync(CommentCreateDto commentDto)
        {
            Comment comment = new Comment()
            {
                EventId = commentDto.EventId,
                AuthorId = commentDto.AuthorId,
                Content = commentDto.Content,
                Timestamp = DateTime.Now,
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime()
            };

            var result = await _repository.CreateAsync(comment);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long commentId)
        {
            var comment = await _repository.GetByIdAsync(commentId);
            if (comment is null) throw new CommentNotFoundException();
            var dbResult = await _repository.DeleteAsync(commentId);
            return dbResult > 0;
        }

        public async Task<IList<Comment>> GetAllAsync(PaginationParams @params)
        {
            var comments = await _repository.GetAllAsync(@params);
            return comments;
        }

        public async Task<Comment> GetByIdAsync(long commentId)
        {
            var comment = await _repository.GetByIdAsync(commentId);
            if (comment is null) throw new CommentNotFoundException();
            else return comment;
        }

        public async Task<bool> UpdateAsync(long commentId, CommentUpdateDto commentDto)
        {
            var comment = await _repository.GetByIdAsync(commentId);
            if (comment is null) throw new CommentNotFoundException();
            comment.EventId = commentDto.EventId;
            comment.AuthorId = commentDto.AuthorId;
            comment.Content = commentDto.Content;
            comment.Timestamp = commentDto.Timestamp;
            comment.UpdatedAt = TimeHelper.GetDateTime();
            var result = await _repository.UpdateAsync(commentId, comment);
            return result > 0;
        }
    }
}