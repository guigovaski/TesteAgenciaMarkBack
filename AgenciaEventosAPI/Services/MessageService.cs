using AgenciaEventosAPI.Data;
using AgenciaEventosAPI.DTOs;
using AgenciaEventosAPI.DTOs.Message;
using AgenciaEventosAPI.DTOs.WhatsApp;
using Microsoft.EntityFrameworkCore;

namespace AgenciaEventosAPI.Services;

public class MessageService : IMessageService
{
    private readonly IEmailService _emailService;
    private readonly IWhatsAppService _wpService;
    private readonly AppDbContext _dbContext;
    
    public MessageService(AppDbContext dbcontext, IEmailService emailService, IWhatsAppService wpService)
    {
        _dbContext = dbcontext;
        _emailService = emailService;
        _wpService = wpService;
    }
    
    public async Task SendMessageAsync(MessageCreateDto messageDto)
    {
        var email = new EmailDto { EventId = messageDto.EventId, Message = messageDto.Message, Author = messageDto.Author, Receiver = messageDto.Receiver, Subject = messageDto.Subject };
        var wpMessage = new WhatsAppDto { EventId = messageDto.EventId, AuthorPhoneNumber = messageDto.AuthorPhoneNumber, ReceiverPhoneNumber = messageDto.ReceiverPhoneNumber, Message = messageDto.Message };
        await _emailService.SendEmailAsync(email);
        await _wpService.SendWpMessageAsync(wpMessage);
    }

    public async Task<MessageResponseDto> GetMessagesByEventAsync(int eventId)
    {
        var eventMessages = await _emailService.GetEmailsByEventAsync(eventId);
        var eventWpMessages = await _wpService.GetWpMessagesByEventAsync(eventId);
        var response = await _dbContext.Events.Include(e => e.WhatsApps)
                                                .Include(e => e.Emails)
                                                .FirstOrDefaultAsync(e => e.EventId == eventId);

        var emails  = response?.Emails.ToList();
        var wpMessages  = response?.WhatsApps.ToList();

        var emailsMapped = new List<EmailDto>();
        var wpMessagesMapped = new List<WhatsAppResponseDto>();
        
        foreach (var message in emails)
        {
            emailsMapped.Add(new EmailDto { EventId = message.EventId, Message = message.Message, Author = message.Author, Receiver = message.Receiver, Subject = message.Subject });
        }
        foreach (var message in wpMessages)
        {
            wpMessagesMapped.Add(new WhatsAppResponseDto { Id = message.WhatsAppId, EventId = message.EventId, Message = message.Message, AuthorPhoneNumber = message.AuthorPhoneNumber, ReceiverPhoneNumber = message.ReceiverPhoneNumber });
        }
        
        return new MessageResponseDto() { Emails = emailsMapped, WhatsApps = wpMessagesMapped, Id = response.EventId, Name = response.Name };
    }
}