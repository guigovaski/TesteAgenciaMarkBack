using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgenciaEventosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddWhatsAppTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Emails_EmailId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EmailId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "WhatsApps",
                columns: table => new
                {
                    WhatsAppId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsApps", x => x.WhatsAppId);
                    table.ForeignKey(
                        name: "FK_WhatsApps_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: 1,
                column: "Message",
                value: "Teste de mensagem do e-mail 1");

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: 2,
                column: "Message",
                value: "Teste de mensagem do e-mail 2");

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: 3,
                column: "Message",
                value: "Teste de mensagem do e-mail 3");

            migrationBuilder.InsertData(
                table: "WhatsApps",
                columns: new[] { "WhatsAppId", "AuthorPhoneNumber", "EventId", "Message", "ReceiverPhoneNumber" },
                values: new object[,]
                {
                    { 1, "41999999999", 1, "Teste de mensagem do whats 1", "41666666666" },
                    { 2, "41888888888", 2, "Teste de mensagem do whats 2", "41555555555" },
                    { 3, "41777777777", 3, "Teste de mensagem do whats 3", "41444444444" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EventId",
                table: "Emails",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsApps_EventId",
                table: "WhatsApps",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Events_EventId",
                table: "Emails",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Events_EventId",
                table: "Emails");

            migrationBuilder.DropTable(
                name: "WhatsApps");

            migrationBuilder.DropIndex(
                name: "IX_Emails_EventId",
                table: "Emails");

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: 1,
                column: "Message",
                value: "Teste de mensagem 1");

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: 2,
                column: "Message",
                value: "Teste de mensagem 2");

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "EmailId",
                keyValue: 3,
                column: "Message",
                value: "Teste de mensagem 3");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EmailId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                column: "EmailId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                column: "EmailId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EmailId",
                table: "Events",
                column: "EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Emails_EmailId",
                table: "Events",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "EmailId");
        }
    }
}
