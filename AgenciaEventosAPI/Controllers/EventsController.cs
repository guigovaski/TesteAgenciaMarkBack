using AgenciaEventosAPI.DTOs;
using AgenciaEventosAPI.Entities;
using AgenciaEventosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AgenciaEventosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(IList<EventDto>))]
    [HttpGet]
    public async Task<ActionResult<IList<Event>>> GetAll()
    {
        var events = await _eventService.GetEventsAsync();
        return Ok(events);
    }
    
    [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(EventDto))]
    [HttpGet("{id:int}", Name = "GetEvent")]
    public async Task<ActionResult<Event>> Get(int id)
    {
        try
        {
            var ev = await _eventService.GetEventAsync(id);
            return Ok(ev);
        }
        catch (Exception ex)
        {
            return NotFound("Producer not found");
        }
    }
    
    [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(EventDto))]
    [HttpPost]
    public async Task<ActionResult<Event>> Post(EventPostDto ev)
    {
        try
        {
            var evCreated = await _eventService.CreateEventAsync(ev);
            return CreatedAtRoute("GetEvent", new { id = evCreated.EventId }, evCreated);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(EventUpdateDto ev)
    {
        try
        {
            var evUpdated = await _eventService.UpdateEventAsync(ev);
            return Ok(evUpdated);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _eventService.DeleteEventAsync(id);
        if (isDeleted)
        {
            return Ok();
        }
        else
        {
            return NotFound("Producer not found");
        }
    }
}