using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebula.Clients.FCB.Apps.Portal.Api.Migrations
{
    public partial class extrafieldsrentfeedbackgart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Clients_ClientId",
                table: "LeaseAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Persons_TenantId",
                table: "LeaseAgreements");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_TenantId",
                table: "LeaseAgreements");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Rents",
                newName: "RentPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "AskPrice",
                table: "Rents",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ContractPrice",
                table: "Rents",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Rents",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Rents",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PointValue",
                table: "Rents",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Rents",
                type: "date",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "LeaseAgreements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Clients_ClientId",
                table: "LeaseAgreements",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Clients_ClientId",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "AskPrice",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "ContractPrice",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "PointValue",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Rents");

            migrationBuilder.RenameColumn(
                name: "RentPrice",
                table: "Rents",
                newName: "Amount");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "LeaseAgreements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_TenantId",
                table: "LeaseAgreements",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Clients_ClientId",
                table: "LeaseAgreements",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Persons_TenantId",
                table: "LeaseAgreements",
                column: "TenantId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
