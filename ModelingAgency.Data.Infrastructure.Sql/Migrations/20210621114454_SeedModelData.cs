using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Migrations
{
    public partial class SeedModelData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Models");

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

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "AddressNumber", "Age", "Aproved", "City", "ClothingSize", "Description", "EMailAdress", "EditOfId", "EyeColor", "HairColor", "Length", "Name", "Postalcode", "TelephoneNumber" },
                values: new object[,]
                {
                    { 1, 12, (short)22, false, "Amsterdam", 38, "Veel energie", "LotteKraamer@gmail.com", null, "Blauw-groen", "Blond", 178, "Lotte", "4623 GH", 612345678 },
                    { 2, 8, (short)24, false, "Groningen", 40, "Rustig", "AnneVanBeekeren@gmail.com", null, "Blauw", "Licht-Bruin", 176, "Anne", "7856 TH", 612341234 },
                    { 3, 3, (short)21, false, "Amersfoort", 36, "Ingetogen", "EmmaVanZuiden@gmail.com", null, "Bruin", "Zwart", 174, "Emma", "5674 UH", 612344567 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2021, 6, 23, 11, 54, 13, 752, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2021, 6, 26, 11, 54, 13, 755, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartTime",
                value: new DateTime(2021, 6, 28, 11, 54, 13, 755, DateTimeKind.Local).AddTicks(7413));
        }
    }
}
