using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebula.Clients.FCB.Apps.Portal.Api.Migrations
{
    public partial class addincomescaletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeScales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinAmount = table.Column<double>(type: "float", nullable: false),
                    MaxAmount = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    RentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeScales", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IncomeScales",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "MaxAmount", "MinAmount", "Percentage", "RentClass", "Scale", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, 2793.0, 0.0, 10.0, "< 23", "< 2793", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, 5587.0, 2793.0100000000002, 12.5, "29 - 58", "2974 - 5587", null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, 8380.0, 5587.0100000000002, 15.0, "69-105", "5588 - 8380", null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, 11173.0, 8380.0100000000002, 18.0, "125 - 168", "8381 - 11173", null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, 13966.0, 11173.01, 21.0, "195 - 224", "11174 - 13966", null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, 16760.0, 13966.01, 24.0, "279 - 335", "13967 - 16760", null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, 19553.0, 67060.009999999995, 27.0, "377 - 440", "16761 - 19553", null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, 22346.0, 19553.009999999998, 30.0, "488 - 559", "19554 - 22346", null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, 999999.0, 22346.009999999998, 30.0, "> 559", "> 22347", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeScales");
        }
    }
}
