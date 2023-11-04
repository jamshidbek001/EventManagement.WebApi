namespace EventManagement.Service.Dtos.Notifications
{
    public class NotificationUpdateDto
    {
        public long RecipientId { get; set; }

        public string Content { get; set; } = String.Empty;

        public DateTime Timestamp { get; set; }

        public bool IsRead { get; set; }
    }
}