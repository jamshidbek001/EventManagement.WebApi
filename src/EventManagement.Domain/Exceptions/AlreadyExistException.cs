using System.Net;

namespace EventManagement.Domain.Exceptions
{
    public class AlreadyExistException : ClientException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

        public override string TitleMessage { get; protected set; } = String.Empty;
    }
}
