namespace EventManagement.Service.Dtos.Comments
{
    public class CommentUpdateDto
    {
        public long EventId { get; set; }

        public long AuthorId { get; set; }

        public string Content { get; set; } = String.Empty;

        public DateTime Timestamp { get; set; }
    }
}