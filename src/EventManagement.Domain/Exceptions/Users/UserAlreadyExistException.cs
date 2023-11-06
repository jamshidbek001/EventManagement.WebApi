namespace EventManagement.Domain.Exceptions.Users
{
    public class UserAlreadyExistException : AlreadyExistException
    {
        public UserAlreadyExistException()
        {
            TitleMessage = "User already exists";
        }

        public UserAlreadyExistException(string email)
        {
            TitleMessage = "This email is already registered";
        }
    }
}