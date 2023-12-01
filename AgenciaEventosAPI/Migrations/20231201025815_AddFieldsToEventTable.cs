using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaEventosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2023, 12, 1, 23, 58, 15, 843, DateTimeKind.Local).AddTicks(2253), "Descrição do evento 1" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2023, 12, 2, 23, 58, 15, 843, DateTimeKind.Local).AddTicks(2269), "Descrição do evento 2" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2023, 12, 3, 23, 58, 15, 843, DateTimeKind.Local).AddTicks(2270), "Descrição do evento 3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");
        }
    }
}
