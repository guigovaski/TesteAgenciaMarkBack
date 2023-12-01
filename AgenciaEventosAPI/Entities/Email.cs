using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AgenciaEventosAPI.Entities;

public class Email
{
    [Key]
    public int EmailId { get; set; }

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
    [Column(TypeName = "nvarchar(max)")]
    public string Message { get; set; }

    public Event? Event { get; set; }
    public int EventId { get; set; }
}