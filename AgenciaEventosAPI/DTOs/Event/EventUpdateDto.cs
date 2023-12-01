using System.ComponentModel.DataAnnotations;

namespace AgenciaEventosAPI.DTOs;

public class EventUpdateDto
{
    [Required]
    public int EventId { get; set; }
    
    [StringLength(255)]
    [Required]
    public string Name { get; set; }
}