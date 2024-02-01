using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebula.Clients.FCB.Apps.Portal.Api.Migrations
{
    public partial class adddebtorcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Complexes_Neighborhoods_NeighborhoodId",
                table: "Complexes");

            migrationBuilder.AlterColumn<int>(
                name: "NeighborhoodId",
                table: "Complexes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientTypeId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebtorCode",
                table: "Clients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId",
                principalTable: "ClientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Complexes_Neighborhoods_NeighborhoodId",
                table: "Complexes",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Complexes_Neighborhoods_NeighborhoodId",
                table: "Complexes");

            migrationBuilder.DropColumn(
                name: "DebtorCode",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "NeighborhoodId",
                table: "Complexes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientTypeId",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientTypes_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId",
                principalTable: "ClientTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Complexes_Neighborhoods_NeighborhoodId",
                table: "Complexes",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id");
        }
    }
}
