namespace EventManagement.Domain.Exceptions.Comments;

public class CommentNotFoundException : NotFoundException
{
    public CommentNotFoundException()
    {
        this.TitleMessage = "Comment not found.";
    }
}