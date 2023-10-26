using EventManagement.DataAccess.Common.Interfaces;
using EventManagement.Domain.Entities.Events;

namespace EventManagement.DataAccess.Interfaces.Events;

public interface IEventRepository :
    IRepository<Event,Event>,IGetAll<Event>
{ }