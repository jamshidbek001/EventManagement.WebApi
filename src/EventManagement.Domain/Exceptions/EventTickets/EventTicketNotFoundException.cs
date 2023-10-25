namespace EventManagement.Domain.Exceptions.EventTickets;

public class EventTicketNotFoundException : NotFoundException
{
    public EventTicketNotFoundException()
    {
        this.TitleMessage = "Event ticket not found.";
    }
}