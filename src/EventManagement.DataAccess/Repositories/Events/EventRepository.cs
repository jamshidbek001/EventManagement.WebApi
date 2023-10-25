using System.Collections.Generic;
using System;
using Dapper;
using EventManagement.DataAccess.Interfaces.Events;
using EventManagement.DataAccess.Utils;
using EventManagement.DataAccess.ViewModels.Events;
using EventManagement.Domain.Entities.Events;

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

            string query = "INSERT INTO public.events(" +
                "id, event_name, date_time, location, description, organizer_id, created_at, updated_at)" +
                "VALUES(@EventName, @DateTime, @Location, @Description, @OrganizerId @CreatedAt, @UpdatedAt);";

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

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Event> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<EventViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Event entity)
    {
        throw new NotImplementedException();
    }
}