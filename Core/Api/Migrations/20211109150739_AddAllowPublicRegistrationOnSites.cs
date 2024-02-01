using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebula.Core.Api.Migrations
{
    public partial class AddAllowPublicRegistrationOnSites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowPublicRegistration",
                table: "Sites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "AllowPublicRegistration", "ClientId", "Core", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Host", "Name", "Port", "SystemName", "UpdatedAt", "UpdatedById" },
                values: new object[] { 103, true, 101, false, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, null, null, "my-fcb.nebula.local", "Mijn FCB", 5000, "Nebula.Clients.FCB.Sites.MyFCB", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DropColumn(
                name: "AllowPublicRegistration",
                table: "Sites")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "SitesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);
        }
    }
}
