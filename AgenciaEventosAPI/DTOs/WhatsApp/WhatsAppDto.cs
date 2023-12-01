using System.ComponentModel.DataAnnotations;
using AgenciaEventosAPI.DTOs.Message;

namespace AgenciaEventosAPI.DTOs.WhatsApp;

public class WhatsAppDto : MessageDto
{
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string AuthorPhoneNumber { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string ReceiverPhoneNumber { get; set; }
}