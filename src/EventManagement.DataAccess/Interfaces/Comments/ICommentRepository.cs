using EventManagement.DataAccess.Common.Interfaces;
using EventManagement.Domain.Entities.Comments;

namespace EventManagement.DataAccess.Interfaces.Comments;

public interface ICommentRepository :
    IRepository<Comment,Comment>,IGetAll<Comment>
{ }