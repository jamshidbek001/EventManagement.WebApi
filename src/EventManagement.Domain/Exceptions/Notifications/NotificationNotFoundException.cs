namespace EventManagement.Domain.Exceptions.Notifications;

public class NotificationNotFoundException : NotFoundException
{
    public NotificationNotFoundException()
    {
        this.TitleMessage = "Notification not found.";
    }
}