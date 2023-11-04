using Dapper;
using EventManagement.DataAccess.Interfaces.Notifications;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Notifications;

namespace EventManagement.DataAccess.Repositories.Notifications;

public class NotificationRepository : BaseRepository, INotificationRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT count(*) FROM notifications";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Notification entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.notifications(recipient_id, content, time_stamp, is_read," +
                "created_at, updated_at) " +
                "VALUES (@RecipientId, @Content, @Timestamp, @IsRead, @CreatedAt, @UpdatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "DELETE FROM notifications WHERE id=@Id";

            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Notification>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM notifications order by id desc" +
                $" offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Notification>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Notification>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Notification?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM notifications where id = {id}";
            var result = await _connection.QuerySingleAsync<Notification>(query);
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Notification entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.notifications SET recipient_id = @RecipientId, content = @Content," +
                $"time_stamp = @Timestamp, is_read = @IsRead, created_at = @CreatedAt, updated_at = @UpdatedAt " +
                $"WHERE id = {id};";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}