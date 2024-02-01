using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebula.Clients.FCB.Apps.Portal.Api.Migrations
{
    public partial class newfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_PersonId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Persons");

            migrationBuilder.AddColumn<bool>(
                name: "InterestedInBuying",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LookingForHouse",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Woningzoekende");

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Ex-Woningzoekende");

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: "Overig");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestedInBuying",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LookingForHouse",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Ingeschreven");

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Overig");

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: "Business partner");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonId",
                table: "Persons",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_PersonId",
                table: "Persons",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
