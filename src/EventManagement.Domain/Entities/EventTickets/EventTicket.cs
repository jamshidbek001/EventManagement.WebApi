namespace EventManagement.Domain.Entities.EventTickets;

public class EventTicket : Auditable
{
    public long EventId { get; set; }

    public string TicketName { get; set; } = String.Empty;

    public double Price { get; set; }

    public int QuantityAvailable { get; set; }

    public DateTime SaleStartDate { get; set; }

    public DateTime SaleEndDate { get; set; }
}