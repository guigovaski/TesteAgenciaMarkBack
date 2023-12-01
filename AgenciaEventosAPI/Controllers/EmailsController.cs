using AgenciaEventosAPI.DTOs;
using AgenciaEventosAPI.Entities;
using AgenciaEventosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AgenciaEventosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailsController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailsController(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    [HttpPost]
    public async Task<IActionResult> SendEmail(EmailDto email)
    {
        try
        {
            await _emailService.SendEmailAsync(email);
            return Ok();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
        }
        
    }
    
    /// <summary>
    /// Lista todos os e-mails de um determinado evento
    /// </summary>
    /// <returns>Os itens da To-do list</returns>
    /// <response code="200">Retorna todos os e-mails de um evento</response>
    [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(IList<EmailDto>))]
    [HttpGet("event/{eventId:int}")]
    public async Task<IActionResult> GetEmailsByEvent(int eventId)
    {
        var eventEmails = await _emailService.GetEmailsByEventAsync(eventId);
        return Ok(eventEmails);
    }
}