namespace EventManagement.Domain.Exceptions.Events;

public class EventNotFoundException : NotFoundException
{
    public EventNotFoundException()
    {
        this.TitleMessage = "Event not found.";
    }
}