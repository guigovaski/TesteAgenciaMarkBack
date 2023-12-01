using System.ComponentModel.DataAnnotations;
using AgenciaEventosAPI.DTOs.Message;

namespace AgenciaEventosAPI.DTOs;

public class EmailDto : MessageDto
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
}