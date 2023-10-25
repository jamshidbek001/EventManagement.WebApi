using EventManagement.DataAccess.Common.Interfaces;
using EventManagement.Domain.Entities.EventRegistrations;

namespace EventManagement.DataAccess.Interfaces.EventRegistrations;

public interface IEventRegistrationRepository :
    IRepository<EventRegistration,EventRegistration>,IGetAll<EventRegistration>
{ }