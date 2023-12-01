using AgenciaEventosAPI.DTOs.WhatsApp;

namespace AgenciaEventosAPI.DTOs.Message;

public class MessageResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<EmailDto> Emails { get; set; }
    public ICollection<WhatsAppResponseDto> WhatsApps { get; set; }
}