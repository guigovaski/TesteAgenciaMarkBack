using AgenciaEventosAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgenciaEventosAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Event>().HasData(
            new Event() { EventId = 1, Name = "Evento 1" },
            new Event() { EventId = 2, Name = "Evento 2" },
            new Event() { EventId = 3, Name = "Evento 3" }
        );
        
        modelBuilder.Entity<Email>().HasData(
            new Email() { EmailId = 1, EventId = 1, Author = "Autor 1", Message = "Teste de mensagem do e-mail 1", Receiver = "Recebedor 1", Subject = "Assunto do e-mail 1" },
            new Email() { EmailId = 2, EventId = 2, Author = "Autor 2", Message = "Teste de mensagem do e-mail 2", Receiver = "Recebedor 2", Subject = "Assunto do e-mail 2" },
            new Email() { EmailId = 3, EventId = 3, Author = "Autor 3", Message = "Teste de mensagem do e-mail 3", Receiver = "Recebedor 3", Subject = "Assunto do e-mail 3" }
        );
        
        modelBuilder.Entity<WhatsApp>().HasData(
            new WhatsApp() { WhatsAppId = 1, EventId = 1, AuthorPhoneNumber = "41999999999", Message = "Teste de mensagem do whats 1", ReceiverPhoneNumber = "41666666666" },
            new WhatsApp() { WhatsAppId = 2, EventId = 2, AuthorPhoneNumber = "41888888888", Message = "Teste de mensagem do whats 2", ReceiverPhoneNumber = "41555555555" },
            new WhatsApp() { WhatsAppId = 3, EventId = 3, AuthorPhoneNumber = "41777777777", Message = "Teste de mensagem do whats 3", ReceiverPhoneNumber = "41444444444" }
        );
    }
    
    public DbSet<Event> Events { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<WhatsApp> WhatsApps { get; set; }
}