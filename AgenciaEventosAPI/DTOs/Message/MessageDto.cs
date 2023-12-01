using System.ComponentModel.DataAnnotations;

namespace AgenciaEventosAPI.DTOs.Message;

public abstract class MessageDto
{
    [Required]
    public string Message { get; set; }
    
    public int EventId { get; set; }
}