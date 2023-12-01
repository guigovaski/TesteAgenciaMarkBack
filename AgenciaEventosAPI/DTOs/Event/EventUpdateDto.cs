using System.ComponentModel.DataAnnotations;

namespace AgenciaEventosAPI.DTOs;

public class EventUpdateDto
{
    public int EventId { get; set; }
    
    [StringLength(255)]
    public string Name { get; set; }
    
    [StringLength(255)]
    public string? Description { get; set; }
    
    public DateTime Date { get; set; }
}