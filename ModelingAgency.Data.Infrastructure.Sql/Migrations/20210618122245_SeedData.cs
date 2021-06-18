using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressNumber = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Postalcode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KVKNumber = table.Column<int>(type: "int", nullable: false),
                    BTWNumber = table.Column<int>(type: "int", nullable: false),
                    EditOfId = table.Column<int>(type: "int", nullable: true),
                    Aproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Clients_EditOfId",
                        column: x => x.EditOfId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressNumber = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Postalcode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Age = table.Column<short>(type: "smallint", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: false),
                    ClothingSize = table.Column<int>(type: "int", nullable: false),
                    TelephoneNumber = table.Column<int>(type: "int", nullable: false),
                    EMailAdress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EditOfId = table.Column<int>(type: "int", nullable: true),
                    Aproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Models_EditOfId",
                        column: x => x.EditOfId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    AddressNumber = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Postalcode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventModel",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    ModelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModel", x => new { x.EventsId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_EventModel_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventModel_Models_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressNumber", "Aproved", "BTWNumber", "City", "EditOfId", "KVKNumber", "Name", "Postalcode" },
                values: new object[] { 1, 45, false, 12345678, "Amsterdam", null, 345678912, "Henk", "1234 GH" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressNumber", "Aproved", "BTWNumber", "City", "EditOfId", "KVKNumber", "Name", "Postalcode" },
                values: new object[] { 2, 15, false, 45678123, "Rotterdam", null, 67891234, "Jaap", "3456 ER" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressNumber", "Aproved", "BTWNumber", "City", "EditOfId", "KVKNumber", "Name", "Postalcode" },
                values: new object[] { 3, 69, false, 89123456, "Groningen", null, 14235867, "Andre", "4567 YU" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EditOfId",
                table: "Clients",
                column: "EditOfId");

            migrationBuilder.CreateIndex(
                name: "IX_EventModel_ModelsId",
                table: "EventModel",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ClientId",
                table: "Events",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ModelId",
                table: "Images",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_EditOfId",
                table: "Models",
                column: "EditOfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventModel");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}
