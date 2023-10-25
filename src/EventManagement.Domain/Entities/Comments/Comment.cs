namespace EventManagement.Domain.Entities.Comments;

public class Comment : Auditable
{
    public long EventId { get; set; }

    public long AuthorId { get; set; }

    public string Content { get; set; } = String.Empty;

    public DateTime Timestamp { get; set; }
}