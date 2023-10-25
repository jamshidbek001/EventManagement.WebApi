using EventManagement.DataAccess.Common.Interfaces;
using EventManagement.DataAccess.ViewModels.Events;
using EventManagement.Domain.Entities.Events;

namespace EventManagement.DataAccess.Interfaces.Events;

public interface IEventRepository :
    IRepository<Event,EventViewModel>,IGetAll<Event>
{ }