using AgenciaEventosAPI.DTOs.WhatsApp;
using AgenciaEventosAPI.Entities;

namespace AgenciaEventosAPI.Services;

public interface IWhatsAppService
{
    Task SendWpMessageAsync(WhatsAppDto message);
    Task<IList<WhatsApp>> GetWpMessagesByEventAsync(int eventId);
    Task<bool> DeleteWpMessageAsync(int eventId);
}