using System.ComponentModel.DataAnnotations;

namespace AgenciaEventosAPI.Entities;

public class Event
{
    [Key]
    public int EventId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    
    public ICollection<Email> Emails { get; set; }
    public ICollection<WhatsApp> WhatsApps { get; set; }
}