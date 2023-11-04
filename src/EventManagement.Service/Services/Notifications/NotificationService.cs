using EventManagement.DataAccess.Interfaces.Notifications;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Notifications;
using EventManagement.Domain.Exceptions.Notifications;
using EventManagement.Service.Common.Helpers;
using EventManagement.Service.Dtos.Notifications;
using EventManagement.Service.Interfaces.Notifications;

namespace EventManagement.Service.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> CountAsync() => await _repository.CountAsync();

        public async Task<bool> CreateAsync(NotificationCreateDto dto)
        {
            Notification notification = new Notification()
            {
                RecipientId = dto.RecipientId,
                Content = dto.Content,
                Timestamp = DateTime.Now,
                IsRead = dto.IsRead,
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime()
            };

            var result = await _repository.CreateAsync(notification);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long notificationId)
        {
            var notification = await _repository.GetByIdAsync(notificationId);
            if (notification is null) throw new NotificationNotFoundException();
            var result = await _repository.DeleteAsync(notificationId);
            return result > 0;
        }

        public async Task<IList<Notification>> GetAllAsync(PaginationParams @params)
        {
            var notifications = await _repository.GetAllAsync(@params);
            return notifications;
        }

        public async Task<Notification> GetByIdAsync(long notificationId)
        {
            var notification = await _repository.GetByIdAsync(notificationId);
            if(notification is null) throw new NotificationNotFoundException();
            else return notification;
        }

        public async Task<bool> UpdateAsync(long notificationId, NotificationUpdateDto dto)
        {
            var notification = await _repository.GetByIdAsync(notificationId);
            if (notification is null) throw new NotificationNotFoundException();
            notification.RecipientId = dto.RecipientId;
            notification.Content = dto.Content;
            notification.Timestamp = dto.Timestamp;
            notification.IsRead = dto.IsRead;
            notification.UpdatedAt = TimeHelper.GetDateTime();
            var result = await _repository.UpdateAsync(notificationId, notification);
            return result > 0;
        }
    }
}