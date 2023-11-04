using EventManagement.DataAccess.Common.Interfaces;
using EventManagement.Domain.Entities.Notifications;

namespace EventManagement.DataAccess.Interfaces.Notifications;

public interface INotificationRepository :
    IRepository<Notification, Notification>, IGetAll<Notification>
{ }