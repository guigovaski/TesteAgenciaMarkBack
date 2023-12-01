using System.ComponentModel.DataAnnotations;

namespace AgenciaEventosAPI.DTOs;

public class EventPostDto
{
    [StringLength(255)]
    [Required]
    public string Name { get; set; }
    
    [StringLength(255)]
    public string? Description { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
}