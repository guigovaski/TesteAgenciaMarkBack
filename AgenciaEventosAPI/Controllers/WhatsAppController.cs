using AgenciaEventosAPI.DTOs.WhatsApp;
using AgenciaEventosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AgenciaEventosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WhatsAppController : ControllerBase
{
    private readonly IWhatsAppService _wpService;

    public WhatsAppController(IWhatsAppService wpService)
    {
        _wpService = wpService;
    }
    
    [HttpPost]
    public async Task<IActionResult> SendWhatsAppMessage(WhatsAppDto wpMessage)
    {
        try
        {
            await _wpService.SendWpMessageAsync(wpMessage);
            return Ok();
        }
        catch (DbUpdateException dbEx)
        {
            Console.WriteLine(dbEx.Message);
            return BadRequest();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
        }
    }
    
    /// <summary>
    /// Lista todos as mensagens de WhatsApp de um determinado evento
    /// </summary>
    /// <returns>Todas as mensagens de WhatsApp do evento</returns>
    /// <response code="200">Retorna todas as mensagens de um evento</response>
    [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(IList<WhatsAppDto>))]
    [HttpGet("events/{eventId:int}")]
    public async Task<IActionResult> GetWpMessagesByEvent(int eventId)
    {
        var eventWpMessages = await _wpService.GetWpMessagesByEventAsync(eventId);
        return Ok(eventWpMessages);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _wpService.DeleteWpMessageAsync(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return Ok();
    }
}