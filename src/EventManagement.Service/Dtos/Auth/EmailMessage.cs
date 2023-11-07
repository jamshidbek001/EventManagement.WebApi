namespace EventManagement.Service.Dtos.Auth
{
    public class EmailMessage
    {
        public string Recipient { get; set; } = String.Empty;

        public string Title { get; set; } = String.Empty;

        public string Content { get; set; } = String.Empty;
    }
}