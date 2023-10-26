using System.Collections.Generic;
using Dapper;
using EventManagement.DataAccess.Interfaces.Events;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Events;
using static Dapper.SqlMapper;

namespace EventManagement.DataAccess.Repositories.Events;

public class EventRepository : BaseRepository, IEventRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT count(*) FROM events";
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

    public async Task<int> CreateAsync(Event entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.events(event_name,date_time,location,description,organizer_id,created_at,updated_at)" +
                "VALUES (@EventName,@DateTime,@Location,@Description,@OrganizerId,@CreatedAt,@UpdatedAt);";

            var result = await _connection.ExecuteAsync(query,entity);
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

            string query = "DELETE FROM events WHERE id=@Id";

            var result = await _connection.ExecuteAsync(query, new { Id=id });
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

    public async Task<IList<Event>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT FROM events order by id desc" +
                $"offset {@params.GetSkipCount} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Event>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Event>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Event> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Event entity)
    {
        throw new NotImplementedException();
    }
}