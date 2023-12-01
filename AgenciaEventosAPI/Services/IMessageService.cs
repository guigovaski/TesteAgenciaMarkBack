using AgenciaEventosAPI.DTOs;
using AgenciaEventosAPI.DTOs.Message;
using AgenciaEventosAPI.DTOs.WhatsApp;

namespace AgenciaEventosAPI.Services;

public interface IMessageService
{
    Task SendMessageAsync(MessageCreateDto message);
    Task<MessageResponseDto> GetMessagesByEventAsync(int eventId);
}