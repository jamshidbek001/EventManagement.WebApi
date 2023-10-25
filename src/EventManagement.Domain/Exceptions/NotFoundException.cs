using System.Net;

namespace EventManagement.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

        public string TitleMessage { get; protected set; } = String.Empty;
    }
}