using EventManagement.DataAccess.Utils;

namespace EventManagement.DataAccess.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int itemCount, IList<TModel>)>
        SearchAsync(string search, PaginationParams @params);
}