using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nebula.Clients.FCB.Apps.Portal.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ClientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valuation = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    AdultQty = table.Column<int>(type: "int", nullable: false),
                    ChildrenQty = table.Column<int>(type: "int", nullable: false),
                    MinorQty = table.Column<int>(type: "int", nullable: false),
                    ClientTypeId = table.Column<int>(type: "int", nullable: true),
                    YearlyIncome = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    MaxRent = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    ChildDiscount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    YearlyIncomeClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Urgency = table.Column<bool>(type: "bit", nullable: false),
                    ApplicantPreferredNeighborhood1Id = table.Column<int>(type: "int", nullable: true),
                    InActive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicantPreferredNeighborhood2Id = table.Column<int>(type: "int", nullable: true),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantPreferredNeighborhood3Id = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientTypes_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Neighborhoods_ApplicantPreferredNeighborhood1Id",
                        column: x => x.ApplicantPreferredNeighborhood1Id,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Neighborhoods_ApplicantPreferredNeighborhood2Id",
                        column: x => x.ApplicantPreferredNeighborhood2Id,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Neighborhoods_ApplicantPreferredNeighborhood3Id",
                        column: x => x.ApplicantPreferredNeighborhood3Id,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Complexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VastCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeighborhoodId = table.Column<int>(type: "int", nullable: true),
                    ConstructionYear = table.Column<int>(type: "int", nullable: false),
                    HouseQty = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Complexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complexes_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MainContact = table.Column<bool>(type: "bit", nullable: false),
                    RelationType = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SchoolGoing = table.Column<bool>(type: "bit", nullable: false),
                    LeftHome = table.Column<bool>(type: "bit", nullable: false),
                    InActive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicantSince = table.Column<DateTime>(type: "date", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NumberOfBedrooms = table.Column<int>(type: "int", nullable: false),
                    SquareMetersBvo = table.Column<int>(type: "int", nullable: false),
                    SquareMetersGo = table.Column<int>(type: "int", nullable: false),
                    SquareMetersFcb = table.Column<int>(type: "int", nullable: false),
                    LandRegistryNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConstructionDate = table.Column<DateTime>(type: "date", nullable: true),
                    AppraisalDate = table.Column<DateTime>(type: "date", nullable: true),
                    RenovationDate = table.Column<DateTime>(type: "date", nullable: true),
                    MarketValue = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    ConstructionCosts = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    RenovationCosts = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    GroundLease = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RentBasePrice = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    RentBasePoints = table.Column<int>(type: "int", nullable: false),
                    NeighborhoodId = table.Column<int>(type: "int", nullable: false),
                    ComplexId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Complexes_ComplexId",
                        column: x => x.ComplexId,
                        principalTable: "Complexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaseAgreements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LeaseAgreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaseAgreements_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaseAgreements_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaseAgreements_Persons_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    LeaseAgreementId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_LeaseAgreements_LeaseAgreementId",
                        column: x => x.LeaseAgreementId,
                        principalTable: "LeaseAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Deleted", "DeletedAt", "DeletedById", "Type", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, "Ingeschreven", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, "Huurder", null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, "Ex-Huurder", null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, "Overig", null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, "Onderneming", null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, "Leverancier", null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, null, null, "Business partner", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ApplicantPreferredNeighborhood1Id",
                table: "Clients",
                column: "ApplicantPreferredNeighborhood1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ApplicantPreferredNeighborhood2Id",
                table: "Clients",
                column: "ApplicantPreferredNeighborhood2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ApplicantPreferredNeighborhood3Id",
                table: "Clients",
                column: "ApplicantPreferredNeighborhood3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Complexes_NeighborhoodId",
                table: "Complexes",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_ComplexId",
                table: "Houses",
                column: "ComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_NeighborhoodId",
                table: "Houses",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_PersonId",
                table: "Incomes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_ClientId",
                table: "LeaseAgreements",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_HouseId",
                table: "LeaseAgreements",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_TenantId",
                table: "LeaseAgreements",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ClientId",
                table: "Persons",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonId",
                table: "Persons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_LeaseAgreementId",
                table: "Rents",
                column: "LeaseAgreementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "LeaseAgreements");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Complexes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropTable(
                name: "Neighborhoods");
        }
    }
}
