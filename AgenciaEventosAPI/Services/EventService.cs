using AgenciaEventosAPI.Data;
using AgenciaEventosAPI.DTOs;
using AgenciaEventosAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaEventosAPI.Services;

public class EventService : IEventService
{
    private readonly AppDbContext _dbContext;
    
    public EventService(AppDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Event> CreateEventAsync(EventPostDto eventDto)
    {
        try
        {
            var eventMapped = new Event
            {
                Name = eventDto.Name,
                Description = eventDto.Description,
                Date = eventDto.Date
            };
            _dbContext.Events.Add(eventMapped);
            await _dbContext.SaveChangesAsync();
            return eventMapped;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception();
        }
    }
    
    public async Task<EventDto> GetEventAsync(int id)
    {
        var ev = await _dbContext.Events.FirstOrDefaultAsync(p => p.EventId == id);
        ArgumentNullException.ThrowIfNull(ev);
        var eventMapped = new EventDto { Name = ev.Name };
        return eventMapped;
    }

    public async Task<IList<EventDto>> GetEventsAsync()
    {
        var events = await _dbContext.Events.ToListAsync();
        var eventsMapped = events.Select(ev => new EventDto { Name = ev.Name, Id = ev.EventId, Date = ev.Date, Description = ev.Description }).ToList();
        return eventsMapped;
    }

    public async Task<EventDto> UpdateEventAsync(EventUpdateDto eventDto)
    {
        var ev = await _dbContext.Events.FirstOrDefaultAsync(p => p.EventId == eventDto.EventId);
        ArgumentNullException.ThrowIfNull(ev);
        
        ev.Name = eventDto.Name;
        ev.Description = eventDto.Description;
        ev.Date = eventDto.Date;
        
        _dbContext.Events.Update(ev);
        await _dbContext.SaveChangesAsync();
        var updatedEvent = await _dbContext.Events.FirstOrDefaultAsync(p => p.EventId == eventDto.EventId);
        ArgumentNullException.ThrowIfNull(updatedEvent);
        
        var eventMappedUpdate = new EventDto
        {
            Name = updatedEvent.Name
        };
        
        return eventMappedUpdate;
    }

    public async Task<bool> DeleteEventAsync(int id)
    {
        var ev = await _dbContext.Events.FirstOrDefaultAsync(p => p.EventId == id);
        if (ev is null)
        {
            return false;
        }
        _dbContext.Events.Remove(ev);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}