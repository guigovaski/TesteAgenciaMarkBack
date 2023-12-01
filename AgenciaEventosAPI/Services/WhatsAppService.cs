using AgenciaEventosAPI.Data;
using AgenciaEventosAPI.DTOs.WhatsApp;
using AgenciaEventosAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgenciaEventosAPI.Services;

public class WhatsAppService : IWhatsAppService
{
    private readonly AppDbContext _dbContext;
    
    public WhatsAppService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task SendWpMessageAsync(WhatsAppDto wpDto)
    {
        var wpMessage = new WhatsApp { EventId = wpDto.EventId, AuthorPhoneNumber = wpDto.AuthorPhoneNumber, ReceiverPhoneNumber = wpDto.ReceiverPhoneNumber, Message = wpDto.Message };
        _dbContext.WhatsApps.Add(wpMessage);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IList<WhatsApp>> GetWpMessagesByEventAsync(int eventId)
    {
        var eventWpMessages = await _dbContext.WhatsApps.Where(wp => wp.EventId == eventId).ToListAsync();
        return eventWpMessages;
    }
}