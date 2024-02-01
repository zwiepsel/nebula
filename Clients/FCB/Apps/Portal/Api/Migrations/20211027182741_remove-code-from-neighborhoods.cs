using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebula.Clients.FCB.Apps.Portal.Api.Migrations
{
    public partial class removecodefromneighborhoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantSince",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Neighborhoods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicantSince",
                table: "Persons",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Neighborhoods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
