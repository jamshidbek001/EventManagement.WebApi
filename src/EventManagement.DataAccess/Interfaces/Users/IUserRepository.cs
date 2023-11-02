using EventManagement.DataAccess.Common.Interfaces;
using EventManagement.DataAccess.ViewModels.Users;
using EventManagement.Domain.Entities.Users;

namespace EventManagement.DataAccess.Interfaces.Users;

public interface IUserRepository :
    IRepository<User,UserViewModel>,IGetAll<UserViewModel>,ISearchable<UserViewModel>
{
    public Task<User?> GetPhoneAsync(string phone);
}