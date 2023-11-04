using Dapper;
using EventManagement.DataAccess.Interfaces.EventTickets;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Events;
using EventManagement.Domain.Entities.EventTickets;

namespace EventManagement.DataAccess.Repositories.EventTickets;

public class EventTicketRepository : BaseRepository, IEventTicketRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT count(*) FROM event_tickets";
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

    public async Task<int> CreateAsync(EventTicket entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.event_tickets(event_id, ticket_name, price, quantity_available," +
                "sales_start_date, sales_end_date, created_at, updated_at) " +
                "VALUES (@EventId, @TicketName, @Price, @QuantityAvailable, @SaleStartDate," +
                "@SaleEndDate, @CreatedAt, @UpdatedAt);";

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
            string query = "DELETE FROM event_tickets WHERE id=@Id";
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

    public async Task<IList<EventTicket>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM event_tickets order by id desc" +
                $" offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<EventTicket>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<EventTicket>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<EventTicket?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM event_tickets where id = { id }";
            var result = await _connection.QuerySingleAsync<EventTicket>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, EventTicket entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.event_tickets SET event_id = @EventId, ticket_name = @TicketName," +
                "price = @Price, quantity_available = @QuantityAvailable, sales_start_date = @SaleStartDate," +
                "sales_end_date = @SaleEndDate, created_at = @CreatedAt, updated_at = @UpdatedAt " +
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