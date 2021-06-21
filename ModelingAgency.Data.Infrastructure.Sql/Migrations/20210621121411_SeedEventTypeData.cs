using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Migrations
{
    public partial class SeedEventTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Evenement waarbij nieuwe producten worden gepresenteerd", "Beurs" },
                    { 2, "Evenement waarbij entertainment rondom een bepaald onderwerp centraal staat", "Conventie" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2021, 6, 23, 14, 14, 10, 530, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2021, 6, 26, 14, 14, 10, 533, DateTimeKind.Local).AddTicks(3731));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartTime",
                value: new DateTime(2021, 6, 28, 14, 14, 10, 533, DateTimeKind.Local).AddTicks(3762));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2021, 6, 23, 13, 44, 53, 946, DateTimeKind.Local).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2021, 6, 26, 13, 44, 53, 948, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartTime",
                value: new DateTime(2021, 6, 28, 13, 44, 53, 948, DateTimeKind.Local).AddTicks(9163));
        }
    }
}
