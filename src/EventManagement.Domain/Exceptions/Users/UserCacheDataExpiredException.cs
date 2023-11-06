namespace EventManagement.Domain.Exceptions.Users
{
    public class UserCacheDataExpiredException : ExpiredException
    {
        public UserCacheDataExpiredException()
        {
            TitleMessage = "User data has expired";
        }
    }
}