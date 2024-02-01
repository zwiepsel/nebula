using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebula.Clients.FCB.Apps.Portal.Api.Migrations
{
    public partial class changeclientStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InActive",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientStatus",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientStatus",
                table: "Clients");

            migrationBuilder.AddColumn<bool>(
                name: "InActive",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
