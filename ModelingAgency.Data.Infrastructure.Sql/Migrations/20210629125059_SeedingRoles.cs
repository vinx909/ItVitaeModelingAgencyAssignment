using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Migrations
{
    public partial class SeedingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c442f02a-d069-4f32-bee6-79cd66ceb456", "fcb1769f-81da-42c3-8ecd-f66a12be42d7", "Client", "CLIENT" },
                    { "b4918047-9530-448a-9c37-88a221fedec4", "23026cfd-8b25-4e83-be14-fd059ed3aad2", "Model", "MODEL" },
                    { "70b22b51-d4bc-4355-b85a-c345098bf0c2", "009454ee-9c01-4aca-86f6-c8e1b727ceb3", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2021, 7, 1, 14, 50, 58, 512, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2021, 7, 4, 14, 50, 58, 516, DateTimeKind.Local).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartTime",
                value: new DateTime(2021, 7, 6, 14, 50, 58, 516, DateTimeKind.Local).AddTicks(5740));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70b22b51-d4bc-4355-b85a-c345098bf0c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4918047-9530-448a-9c37-88a221fedec4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c442f02a-d069-4f32-bee6-79cd66ceb456");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2021, 6, 27, 14, 52, 20, 604, DateTimeKind.Local).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2021, 6, 30, 14, 52, 20, 607, DateTimeKind.Local).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartTime",
                value: new DateTime(2021, 7, 2, 14, 52, 20, 607, DateTimeKind.Local).AddTicks(5116));
        }
    }
}
