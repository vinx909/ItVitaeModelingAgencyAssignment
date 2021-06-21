using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Migrations
{
    public partial class CheckFluentApiThroughExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Clients_ClientId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Models_ModelId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "ModelId",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressNumber", "ClientId", "Description", "Duration", "EventTypeId", "Name", "Postalcode", "StartTime" },
                values: new object[] { 1, 12, null, "Show met auto's", 3, null, "Auto show", "3568 GG", new DateTime(2021, 6, 23, 11, 54, 13, 752, DateTimeKind.Local).AddTicks(7775) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressNumber", "ClientId", "Description", "Duration", "EventTypeId", "Name", "Postalcode", "StartTime" },
                values: new object[] { 2, 3, null, "Evenement rondom anime", 3, null, "Anime con", "4201 BR", new DateTime(2021, 6, 26, 11, 54, 13, 755, DateTimeKind.Local).AddTicks(7317) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressNumber", "ClientId", "Description", "Duration", "EventTypeId", "Name", "Postalcode", "StartTime" },
                values: new object[] { 3, 7, null, "Show met verzamel items", 1, null, "Verzamelbeurs", "6734 TY", new DateTime(2021, 6, 28, 11, 54, 13, 755, DateTimeKind.Local).AddTicks(7413) });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Clients_ClientId",
                table: "Events",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Models_ModelId",
                table: "Images",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Clients_ClientId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Models_ModelId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "ModelId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Clients_ClientId",
                table: "Events",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Models_ModelId",
                table: "Images",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
