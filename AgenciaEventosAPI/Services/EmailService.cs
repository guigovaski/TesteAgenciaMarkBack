using AgenciaEventosAPI.Data;
using AgenciaEventosAPI.DTOs;
using AgenciaEventosAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgenciaEventosAPI.Services;

public class EmailService : IEmailService
{
    private readonly AppDbContext _dbContext;
    
    public EmailService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task SendEmailAsync(EmailDto emailDto)
    {
        var email = new Email { EventId = emailDto.EventId, Author = emailDto.Author, Receiver = emailDto.Receiver, Subject = emailDto.Subject, Message = emailDto.Message };
        _dbContext.Emails.Add(email);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IList<Email>> GetEmailsByEventAsync(int eventId)
    {
        var eventEmails = await _dbContext.Emails.Where(e => e.EventId == eventId).ToListAsync();
        return eventEmails;
    }
}