namespace EventManagement.Domain.Exceptions.EventRegistrations;

public class EventRegistrationNotFoundException : NotFoundException
{
    public EventRegistrationNotFoundException()
    {
        this.TitleMessage = "Event registration not found.";
    }
}