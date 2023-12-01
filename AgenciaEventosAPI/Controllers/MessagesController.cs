using AgenciaEventosAPI.DTOs.Message;
using AgenciaEventosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AgenciaEventosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessagesController(IMessageService messageService)
    {
        _messageService = messageService;
    }
    
    [HttpPost]
    public async Task<IActionResult> SendMessage(MessageCreateDto message)
    {
        await _messageService.SendMessageAsync(message);
        return Ok();
    }
    
    /// <summary>
    /// Lista todas as mensagens de um evento, incluindo WhatsApp e E-mail
    /// </summary>
    /// <returns>Retorna todas as mensagens de um evento, incluindo WhatsApp e E-mail</returns>
    /// <response code="200">Retorna todas as mensagens de um evento, incluindo WhatsApp e E-mail</response>
    [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(IList<MessageResponseDto>))]
    [HttpGet("events/{eventId:int}")]
    public async Task<ActionResult<IList<MessageResponseDto>>> GetMessagesByEvent(int eventId)
    {
        var eventEmails = await _messageService.GetMessagesByEventAsync(eventId);
        return Ok(eventEmails);
    }
}