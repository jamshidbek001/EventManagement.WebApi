namespace EventManagement.Domain.Exceptions.Auth
{
    public class VerificationTooManyRequestException : TooManyRequestException
    {
        public VerificationTooManyRequestException()
        {
            TitleMessage = "You tried more than limits";
        }
    }
}