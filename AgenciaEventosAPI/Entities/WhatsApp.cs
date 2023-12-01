using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEventosAPI.Entities;

public class WhatsApp
{
    [Key]
    public int WhatsAppId { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string AuthorPhoneNumber { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string ReceiverPhoneNumber { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(max)")]
    public string Message { get; set; }

    public Event? Event { get; set; }
    public int EventId { get; set; }
}