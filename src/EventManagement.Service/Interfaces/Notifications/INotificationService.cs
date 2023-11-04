using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Notifications;
using EventManagement.Service.Dtos.Notifications;

namespace EventManagement.Service.Interfaces.Notifications
{
    public interface INotificationService
    {
        public Task<bool> CreateAsync(NotificationCreateDto dto);

        public Task<long> CountAsync();

        public Task<bool> DeleteAsync(long notificationId);

        public Task<IList<Notification>> GetAllAsync(PaginationParams @params);

        public Task<Notification> GetByIdAsync(long notificationId);

        public Task<bool> UpdateAsync(long notificationId, NotificationUpdateDto dto);
    }
}