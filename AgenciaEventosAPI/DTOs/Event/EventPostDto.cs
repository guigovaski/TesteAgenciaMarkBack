using System.ComponentModel.DataAnnotations;

namespace AgenciaEventosAPI.DTOs;

public class EventPostDto
{
    [StringLength(255)]
    [Required]
    public string Name { get; set; }
}