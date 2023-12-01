using System.ComponentModel.DataAnnotations;

namespace AgenciaEventosAPI.DTOs;

public class EventDto
{
    [Required]
    public int Id { get; set; }
    
    [StringLength(255)]
    [Required]
    public string Name { get; set; }
}