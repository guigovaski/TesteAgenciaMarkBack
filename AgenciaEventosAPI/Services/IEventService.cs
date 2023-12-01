using AgenciaEventosAPI.DTOs;
using AgenciaEventosAPI.Entities;

namespace AgenciaEventosAPI.Services;

public interface IEventService
{
    Task<Event> CreateEventAsync(EventPostDto producer);
    Task<EventDto> GetEventAsync(int id);
    Task<IList<EventDto>> GetEventsAsync();
    Task<EventDto> UpdateEventAsync(EventUpdateDto producer);
    Task<bool> DeleteEventAsync(int id);
}