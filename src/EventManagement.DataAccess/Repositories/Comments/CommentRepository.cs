using Dapper;
using EventManagement.DataAccess.Interfaces.Comments;
using EventManagement.DataAccess.Utils;
using EventManagement.Domain.Entities.Comments;

namespace EventManagement.DataAccess.Repositories.Comments;

public class CommentRepository : BaseRepository, ICommentRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT count(*) FROM comments";
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

    public async Task<int> CreateAsync(Comment entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.comments(event_id, author_id, content, time_stamp, created_at, updated_at) " +
                "VALUES (@EventId, @AuthorId, @Content, @Timestamp, @CreatedAt, @UpdatedAt);";

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
            string query = $"DELETE FROM comments WHERE id = @Id";
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

    public async Task<IList<Comment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM comments order by id desc offset " +
                $"{@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Comment>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Comment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Comment?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM comments WHERE id = {id}";
            var result = await _connection.QuerySingleAsync<Comment>(query);
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

    public async Task<int> UpdateAsync(long id, Comment entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.comments SET event_id = @EventId, author_id = @AuthorId," +
                $"content = @Content, time_stamp = @Timestamp, created_at = @CreatedAt, updated_at = @UpdatedAt " +
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