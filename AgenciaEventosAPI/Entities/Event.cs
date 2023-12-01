using System.ComponentModel.DataAnnotations;

namespace AgenciaEventosAPI.Entities;

public class Event
{
    [Key]
    public int EventId { get; set; }
    
    [StringLength(255)]
    public string Name { get; set; }
    
    public ICollection<Email> Emails { get; set; }
    public ICollection<WhatsApp> WhatsApps { get; set; }
}