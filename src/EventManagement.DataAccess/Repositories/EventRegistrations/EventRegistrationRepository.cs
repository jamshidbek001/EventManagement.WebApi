using Dapper;
using EventManagement.DataAccess.Interfaces.EventRegistrations;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.EventRegistrations;
using EventManagement.Domain.Entities.Events;

namespace EventManagement.DataAccess.Repositories.EventRegistrations;

public class EventRegistrationRepository : BaseRepository, IEventRegistrationRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT count(*) FROM event_registration";
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

    public async Task<int> CreateAsync(EventRegistration entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.event_registration(event_id, attendee_id, numberof_tickets, total_price," +
                "registration_date, payment_status, created_at, updated_at) " +
                "VALUES (@EventId, @AttendeeId, @NumberOfTickets, @TotalPrice, @RegistrationDate," +
                "@PatmentStatus, @CreatedAt, @UpdatedAt);";

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
            string query = "DELETE FROM event_registration WHERE id = @Id";
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

    public async Task<IList<EventRegistration>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM event_registration order by id desc" +
                $" offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<EventRegistration>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<EventRegistration>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<EventRegistration?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM event_registration where id = { id }";
            var result = await _connection.QuerySingleAsync<EventRegistration>(query);
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

    public async Task<int> UpdateAsync(long id, EventRegistration entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.event_registration SET event_id = @EventId, attendee_id = @AttendeeId," +
                "numberof_tickets = @NumberOfTickets, total_price = @TotalPrice, registration_date = @RegistrationDate," +
                "payment_status = @PaymentStatus, created_at = @CreatedAt, updated_at = @UpdatedAt " +
                $"WHERE id = { id };";

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