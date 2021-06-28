using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Migrations
{
    public partial class NAWonModelAndClientAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_EditOfId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "AddressNumber",
                table: "Models",
                type: "int",
                maxLength: 6,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Models",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Models",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressNumber",
                table: "Clients",
                type: "int",
                maxLength: 6,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Clients",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EditOfId",
                table: "Clients",
                column: "EditOfId",
                unique: true,
                filter: "[EditOfId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_EditOfId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AddressNumber",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "AddressNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EditOfId",
                table: "Clients",
                column: "EditOfId");
        }
    }
}
