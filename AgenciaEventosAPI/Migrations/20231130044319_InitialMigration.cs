using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgenciaEventosAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    EmailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Emails_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Emails",
                        principalColumn: "EmailId");
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "EmailId", "Author", "EventId", "Message", "Receiver", "Subject" },
                values: new object[,]
                {
                    { 1, "Autor 1", 1, "Teste de mensagem 1", "Recebedor 1", "Assunto do e-mail 1" },
                    { 2, "Autor 2", 2, "Teste de mensagem 2", "Recebedor 2", "Assunto do e-mail 2" },
                    { 3, "Autor 3", 3, "Teste de mensagem 3", "Recebedor 3", "Assunto do e-mail 3" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "EmailId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Evento 1" },
                    { 2, null, "Evento 2" },
                    { 3, null, "Evento 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EmailId",
                table: "Events",
                column: "EmailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Emails");
        }
    }
}
