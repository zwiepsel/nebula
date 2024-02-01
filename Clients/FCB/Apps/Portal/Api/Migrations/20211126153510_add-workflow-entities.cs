using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebula.Clients.FCB.Apps.Portal.Api.Migrations
{
    public partial class addworkflowentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_ProcessStructures_ProcessStructureId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_ProcessStructureId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "AfterStep",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "QueryCondition",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "SiteUserGroupId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "SiteUserId",
                table: "Processes");

            migrationBuilder.RenameColumn(
                name: "StepNr",
                table: "Processes",
                newName: "ProcessTypeId");

            migrationBuilder.RenameColumn(
                name: "StepName",
                table: "Processes",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "ProcessTypeIdComplete",
                table: "ProcessTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                table: "ProcessTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TriggerTypeId",
                table: "ProcessTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompletionDays",
                table: "ProcessStructures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProcessStructures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProcessDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    StepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AfterStep = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    SiteUserId = table.Column<int>(type: "int", nullable: true),
                    SiteUserGroupId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ProcessDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessDetail_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_RequestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TriggerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_TriggerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    SiteUserId = table.Column<int>(type: "int", nullable: true),
                    Ref1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeScaleId = table.Column<int>(type: "int", nullable: false),
                    AdultQty = table.Column<int>(type: "int", nullable: false),
                    ChildrenQty = table.Column<int>(type: "int", nullable: false),
                    RequestStatusId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Request_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Request_IncomeScales_IncomeScaleId",
                        column: x => x.IncomeScaleId,
                        principalTable: "IncomeScales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Request_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessRequest",
                columns: table => new
                {
                    ProcessesId = table.Column<int>(type: "int", nullable: false),
                    RequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessRequest", x => new { x.ProcessesId, x.RequestsId });
                    table.ForeignKey(
                        name: "FK_ProcessRequest_Processes_ProcessesId",
                        column: x => x.ProcessesId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessRequest_Request_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessDetailId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteUserId = table.Column<int>(type: "int", nullable: false),
                    TaskStatusId = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    AfterStep = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_ProcessDetail_ProcessDetailId",
                        column: x => x.ProcessDetailId,
                        principalTable: "ProcessDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AgeScales",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "MaxAge", "MinAge", "Scale", "UpdatedAt", "UpdatedById" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, null, null, 20, 0, "1", null, null });

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[] { 5, new DateTime(2021, 11, 26, 11, 35, 10, 300, DateTimeKind.Local).AddTicks(6492), 1, false, null, null, "Sedula", null, null });

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 1,
                column: "Scale",
                value: "< $2793");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 2,
                column: "Scale",
                value: "$2974 - $5587");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 3,
                column: "Scale",
                value: "$5588 - $8380");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 4,
                column: "Scale",
                value: "$8381 - $11173");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 5,
                column: "Scale",
                value: "$11174 - $13966");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 6,
                column: "Scale",
                value: "$13967 - $16760");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 7,
                column: "Scale",
                value: "$16761 - $19553");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 8,
                column: "Scale",
                value: "$19554 - $22346");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 9,
                column: "Scale",
                value: "> $22347");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessTypes_RequestTypeId",
                table: "ProcessTypes",
                column: "RequestTypeId",
                unique: true,
                filter: "[RequestTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessTypes_TriggerTypeId",
                table: "ProcessTypes",
                column: "TriggerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_ProcessTypeId",
                table: "Processes",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ClientId",
                table: "Files",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_RequestId",
                table: "Files",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDetail_ProcessId",
                table: "ProcessDetail",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequest_RequestsId",
                table: "ProcessRequest",
                column: "RequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ClientId",
                table: "Request",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_HouseId",
                table: "Request",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_IncomeScaleId",
                table: "Request",
                column: "IncomeScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PersonId",
                table: "Request",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestTypeId",
                table: "Request",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProcessDetailId",
                table: "Task",
                column: "ProcessDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_RequestId",
                table: "Task",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Clients_ClientId",
                table: "Files",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Request_RequestId",
                table: "Files",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_ProcessTypes_ProcessTypeId",
                table: "Processes",
                column: "ProcessTypeId",
                principalTable: "ProcessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessTypes_RequestType_RequestTypeId",
                table: "ProcessTypes",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessTypes_TriggerType_TriggerTypeId",
                table: "ProcessTypes",
                column: "TriggerTypeId",
                principalTable: "TriggerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Clients_ClientId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Request_RequestId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Processes_ProcessTypes_ProcessTypeId",
                table: "Processes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessTypes_RequestType_RequestTypeId",
                table: "ProcessTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessTypes_TriggerType_TriggerTypeId",
                table: "ProcessTypes");

            migrationBuilder.DropTable(
                name: "ProcessRequest");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TriggerType");

            migrationBuilder.DropTable(
                name: "ProcessDetail");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "RequestType");

            migrationBuilder.DropIndex(
                name: "IX_ProcessTypes_RequestTypeId",
                table: "ProcessTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProcessTypes_TriggerTypeId",
                table: "ProcessTypes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_ProcessTypeId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Files_ClientId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_RequestId",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "AgeScales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FileTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ProcessTypeIdComplete",
                table: "ProcessTypes");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                table: "ProcessTypes");

            migrationBuilder.DropColumn(
                name: "TriggerTypeId",
                table: "ProcessTypes");

            migrationBuilder.DropColumn(
                name: "CompletionDays",
                table: "ProcessStructures");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProcessStructures");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "ProcessTypeId",
                table: "Processes",
                newName: "StepNr");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Processes",
                newName: "StepName");

            migrationBuilder.AddColumn<int>(
                name: "AfterStep",
                table: "Processes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QueryCondition",
                table: "Processes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteUserGroupId",
                table: "Processes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteUserId",
                table: "Processes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 1,
                column: "Scale",
                value: "< 2793");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 2,
                column: "Scale",
                value: "2974 - 5587");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 3,
                column: "Scale",
                value: "5588 - 8380");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 4,
                column: "Scale",
                value: "8381 - 11173");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 5,
                column: "Scale",
                value: "11174 - 13966");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 6,
                column: "Scale",
                value: "13967 - 16760");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 7,
                column: "Scale",
                value: "16761 - 19553");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 8,
                column: "Scale",
                value: "19554 - 22346");

            migrationBuilder.UpdateData(
                table: "IncomeScales",
                keyColumn: "Id",
                keyValue: 9,
                column: "Scale",
                value: "> 22347");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_ProcessStructureId",
                table: "Processes",
                column: "ProcessStructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_ProcessStructures_ProcessStructureId",
                table: "Processes",
                column: "ProcessStructureId",
                principalTable: "ProcessStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
