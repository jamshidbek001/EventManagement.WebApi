using EventManagement.DataAccess.Utils;

namespace EventManagement.DataAccess.Common.Interfaces
{
    public interface IGetAll<TModel>
    {
        public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
    }
}