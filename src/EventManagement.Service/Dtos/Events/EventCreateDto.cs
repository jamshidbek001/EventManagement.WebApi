namespace EventManagement.Service.Dtos.Events;

public class EventCreateDto
{
    public string EventName { get; set; } = String.Empty;

    public DateTime DateTime { get; set; }

    public string Location { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;
}