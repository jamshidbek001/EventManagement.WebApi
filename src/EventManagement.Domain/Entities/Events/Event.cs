namespace EventManagement.Domain.Entities.Events;

public class Event : Auditable
{
    public string EventName { get; set; } = String.Empty;

    public DateTime DateTime { get; set; }

    public string Location { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public long OrganizerId { get; set; }
}