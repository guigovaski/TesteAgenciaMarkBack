using AgenciaEventosAPI.DTOs;
using AgenciaEventosAPI.Entities;

namespace AgenciaEventosAPI.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailDto email);
    Task<IList<Email>> GetEmailsByEventAsync(int eventId);
}