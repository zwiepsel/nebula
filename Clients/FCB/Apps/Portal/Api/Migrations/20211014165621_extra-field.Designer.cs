﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Data;

#nullable disable

namespace Nebula.Clients.FCB.Apps.Portal.Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211014165621_extra-field")]
    partial class extrafield
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-rc.1.21452.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AdultQty")
                        .HasColumnType("int");

                    b.Property<string>("AgeClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ApplicantPreferredNeighborhood1Id")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicantPreferredNeighborhood2Id")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicantPreferredNeighborhood3Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ApplicationDate")
                        .HasColumnType("Date");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("int");

                    b.Property<decimal>("ChildDiscount")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("ChildrenQty")
                        .HasColumnType("int");

                    b.Property<int?>("ClientTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("FamilyState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InActive")
                        .HasColumnType("bit");

                    b.Property<bool>("InterestedInBuying")
                        .HasColumnType("bit");

                    b.Property<bool>("LookingForHouse")
                        .HasColumnType("bit");

                    b.Property<decimal>("MaxRent")
                        .HasColumnType("decimal(19,4)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinorQty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<bool>("Urgency")
                        .HasColumnType("bit");

                    b.Property<decimal>("YearlyIncome")
                        .HasColumnType("decimal(19,4)");

                    b.Property<string>("YearlyIncomeClass")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantPreferredNeighborhood1Id");

                    b.HasIndex("ApplicantPreferredNeighborhood2Id");

                    b.HasIndex("ApplicantPreferredNeighborhood3Id");

                    b.HasIndex("ClientTypeId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClientTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = 0,
                            Deleted = false,
                            Type = "Woningzoekende"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = 0,
                            Deleted = false,
                            Type = "Huurder"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = 0,
                            Deleted = false,
                            Type = "Ex-Huurder"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = 0,
                            Deleted = false,
                            Type = "Ex-Woningzoekende"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = 0,
                            Deleted = false,
                            Type = "Onderneming"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = 0,
                            Deleted = false,
                            Type = "Leverancier"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = 0,
                            Deleted = false,
                            Type = "Overig"
                        });
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Complex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConstructionYear")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<int>("HouseQty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<string>("VastCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NeighborhoodId");

                    b.ToTable("Complexes");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("AppraisalDate")
                        .HasColumnType("date");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ComplexId")
                        .HasColumnType("int");

                    b.Property<decimal>("ConstructionCosts")
                        .HasColumnType("decimal(19,4)");

                    b.Property<DateTime?>("ConstructionDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<decimal?>("GroundLease")
                        .HasColumnType("decimal(19,4)");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LandRegistryNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("MarketValue")
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfBedrooms")
                        .HasColumnType("int");

                    b.Property<decimal?>("RenovationCosts")
                        .HasColumnType("decimal(19,4)");

                    b.Property<DateTime?>("RenovationDate")
                        .HasColumnType("date");

                    b.Property<int>("RentBasePoints")
                        .HasColumnType("int");

                    b.Property<decimal>("RentBasePrice")
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("SquareMetersBvo")
                        .HasColumnType("int");

                    b.Property<int>("SquareMetersFcb")
                        .HasColumnType("int");

                    b.Property<int>("SquareMetersGo")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComplexId");

                    b.HasIndex("NeighborhoodId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(19,4)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.LeaseAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("HouseId");

                    b.ToTable("LeaseAgreements");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Neighborhood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<int>("Valuation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ApplicantSince")
                        .HasColumnType("date");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("CountryOfBirth")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("InActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LeftHome")
                        .HasColumnType("bit");

                    b.Property<bool>("MainContact")
                        .HasColumnType("bit");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Prefix")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RelationType")
                        .HasColumnType("int");

                    b.Property<bool>("SchoolGoing")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AskPrice")
                        .HasColumnType("decimal(19,4)");

                    b.Property<decimal>("ContractPrice")
                        .HasColumnType("decimal(19,4)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(19,4)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("LeaseAgreementId")
                        .HasColumnType("int");

                    b.Property<decimal>("PointValue")
                        .HasColumnType("decimal(19,4)");

                    b.Property<decimal>("RentPrice")
                        .HasColumnType("decimal(19,4)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeaseAgreementId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Client", b =>
                {
                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Neighborhood", "ApplicantPreferredNeighborhood1")
                        .WithMany()
                        .HasForeignKey("ApplicantPreferredNeighborhood1Id");

                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Neighborhood", "ApplicantPreferredNeighborhood2")
                        .WithMany()
                        .HasForeignKey("ApplicantPreferredNeighborhood2Id");

                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Neighborhood", "ApplicantPreferredNeighborhood3")
                        .WithMany()
                        .HasForeignKey("ApplicantPreferredNeighborhood3Id");

                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.ClientType", "ClientType")
                        .WithMany()
                        .HasForeignKey("ClientTypeId");

                    b.Navigation("ApplicantPreferredNeighborhood1");

                    b.Navigation("ApplicantPreferredNeighborhood2");

                    b.Navigation("ApplicantPreferredNeighborhood3");

                    b.Navigation("ClientType");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Complex", b =>
                {
                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Neighborhood", "Neighborhood")
                        .WithMany()
                        .HasForeignKey("NeighborhoodId");

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.House", b =>
                {
                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Complex", "Complex")
                        .WithMany()
                        .HasForeignKey("ComplexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Neighborhood", "Neighborhood")
                        .WithMany()
                        .HasForeignKey("NeighborhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Complex");

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Income", b =>
                {
                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Person", "Person")
                        .WithMany("Incomes")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.LeaseAgreement", b =>
                {
                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Client", "Client")
                        .WithMany("LeaseAgreements")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.House", "House")
                        .WithMany("LeaseAgreements")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("House");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Person", b =>
                {
                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Client", "Client")
                        .WithMany("Persons")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Rent", b =>
                {
                    b.HasOne("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.LeaseAgreement", "LeaseAgreement")
                        .WithMany("Rents")
                        .HasForeignKey("LeaseAgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaseAgreement");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Client", b =>
                {
                    b.Navigation("LeaseAgreements");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.House", b =>
                {
                    b.Navigation("LeaseAgreements");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.LeaseAgreement", b =>
                {
                    b.Navigation("Rents");
                });

            modelBuilder.Entity("Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities.Person", b =>
                {
                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
