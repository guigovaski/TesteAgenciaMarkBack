using System.ComponentModel.DataAnnotations;

namespace AgenciaEventosAPI.DTOs.Message;

public class MessageCreateDto : MessageDto
{
    [Required]
    [StringLength(255)]
    public string Subject { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Author { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Receiver { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string AuthorPhoneNumber { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string ReceiverPhoneNumber { get; set; }
}