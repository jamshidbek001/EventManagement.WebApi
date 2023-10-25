namespace EventManagement.Domain.Entities.EventRegistrations;

public class EventRegistration : Auditable
{
    public long EventId { get; set; }

    public long AttendeeId { get; set; }

    public int NumberOfTickets { get; set; }

    public double TotalPrice { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool PaymentStatus { get; set; }
}