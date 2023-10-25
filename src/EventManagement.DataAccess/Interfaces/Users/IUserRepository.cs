using EventManagement.DataAccess.Common.Interfaces;
using EventManagement.Domain.Entities.Users;

namespace EventManagement.DataAccess.Interfaces.Users;

public interface IUserRepository :
    IRepository<User,User>,IGetAll<User>
{ }