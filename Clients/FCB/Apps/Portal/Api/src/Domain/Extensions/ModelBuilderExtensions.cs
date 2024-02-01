using System;
using Microsoft.EntityFrameworkCore;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Clients.FCB.Shared.Enums;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedPersons(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasData(
            new Person
            {
                Id = 1,
                FirstName = "First name 1",
                LastName = "Last name 1",
                EmailAddress = "person-1@email.com",
                PhoneNumber = "+123456789",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1970, 1, 1),
                CountryOfBirth = "Curacao",
                Nationality = "Dutch",
                SchoolGoing = false,
                CreatedById = 1
            },
            new Person
            {
                Id = 2,
                FirstName = "First name 2",
                LastName = "Last name 2",
                EmailAddress = "person-2@email.com",
                PhoneNumber = "+123456789",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1980, 1, 1),
                CountryOfBirth = "Curacao",
                Nationality = "Dutch",
                SchoolGoing = false,
                CreatedById = 1
            },
            new Person
            {
                Id = 3,
                FirstName = "First name 3",
                LastName = "Last name 3",
                EmailAddress = "person-3@email.com",
                PhoneNumber = "+123456789",
                Gender = Gender.Other,
                DateOfBirth = new DateTime(1990, 1, 1),
                CountryOfBirth = "Curacao",
                Nationality = "Dutch",
                SchoolGoing = false,

                CreatedById = 1
            },
            new Person
            {
                Id = 4,
                FirstName = "First name 4",
                LastName = "Last name 4",
                EmailAddress = "person-4@email.com",
                PhoneNumber = "+123456789",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2000, 1, 1),
                CountryOfBirth = "Curacao",
                Nationality = "Dutch",
                SchoolGoing = true,
                CreatedById = 1
            },
            new Person
            {
                Id = 5,
                FirstName = "First name 5",
                LastName = "Last name 5",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2010, 1, 1),
                CountryOfBirth = "Curacao",
                Nationality = "Dutch",
                SchoolGoing = true,
                CreatedById = 1
            },
            new Person
            {
                Id = 6,
                FirstName = "First name 6",
                LastName = "Last name 6",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2010, 1, 1),
                CountryOfBirth = "Curacao",
                Nationality = "Dutch",
                SchoolGoing = true,
                CreatedById = 1
            },
            new Person
            {
                Id = 7,
                FirstName = "First name 7",
                LastName = "Last name 7",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2010, 6, 1),
                CountryOfBirth = "Curacao",
                Nationality = "Dutch",
                SchoolGoing = true,
                CreatedById = 1
            },
            new Person
            {
                Id = 8,
                FirstName = "First name 8",
                LastName = "Last name 8",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2020, 6, 1),
                CountryOfBirth = "Curacao",
                Nationality = "Dutch",
                SchoolGoing = false,
                CreatedById = 1
            }
        );
    }

    public static void SeedFileTypes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileType>().HasData(
            new FileType
            {
                Id = 5,
                CreatedAt = DateTime.Now,
                CreatedById = 1,
                Deleted = false,
                Name = "Sedula"
            }
        );
    }

    public static void SeedLeaseAgreements(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeaseAgreement>().HasData(
            new LeaseAgreement
            {
                Id = 1,
                StartDate = new DateTime(2010, 1, 1),
                EndDate = new DateTime(2020, 1, 1),
                HouseId = 1,
                CreatedById = 1
            },
            new LeaseAgreement
            {
                Id = 2,
                StartDate = new DateTime(2015, 1, 1),
                EndDate = new DateTime(2025, 1, 1),
                HouseId = 2,
                CreatedById = 1
            },
            new LeaseAgreement
            {
                Id = 3,
                StartDate = new DateTime(2020, 1, 1),
                EndDate = new DateTime(2030, 1, 1),
                HouseId = 3,
                CreatedById = 1
            }
        );
    }
    
    public static void SeedClientTypes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientType>().HasData(
            new ClientType
            {
                Id = 1,
                Type = "Woningzoekende"
            },
            new ClientType
            {
                Id = 2,
                Type = "Huurder"
            },
            new ClientType
            {
                Id = 3,
                Type = "Ex-Huurder"
            },
            new ClientType
            {
                Id = 4,
                Type = "Ex-Woningzoekende"
            },
            new ClientType
            {
                Id = 5,
                Type = "Onderneming"
            },
            new ClientType
            {
                Id = 6,
                Type = "Leverancier"
            },
            new ClientType
            {
                Id = 7,
                Type = "Overig"
            }
        );
    }

    public static void SeedRents(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rent>().HasData(
            new Rent { Id = 1, AskPrice = 250m, LeaseAgreementId = 1, CreatedById = 1 },
            new Rent { Id = 2, AskPrice = 350m, LeaseAgreementId = 2, CreatedById = 1 },
            new Rent { Id = 3, AskPrice = 150m, LeaseAgreementId = 3, CreatedById = 1 }
        );
    }

    public static void SeedAgeScales(this ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<AgeScale>().HasData(
           new AgeScale { Id = 1, Scale = "1", MinAge = 0, MaxAge = 20, Deleted = false, CreatedById = 1}
           );
    }
    
    public static void SeedIncomeScales(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IncomeScale>().HasData(
            new IncomeScale
            {
                Id = 1,
                Scale = "< $2793",
                MinAmount = 0,
                MaxAmount = 2793,
                Percentage = 10,
                RentClass = "< 23"
                
   
            },
            new IncomeScale
            {
                Id = 2,
                Scale = "$2974 - $5587",
                MinAmount = 2793.01,
                MaxAmount = 5587,
                Percentage = 12.5,
                RentClass = "29 - 58"

            },
            new IncomeScale
            {
                Id = 3,
                Scale = "$5588 - $8380",
                MinAmount = 5587.01,
                MaxAmount = 8380,
                Percentage = 15,
                RentClass = "69-105"

            },
            new IncomeScale
            {
                Id = 4,
                Scale = "$8381 - $11173",
                MinAmount = 8380.01,
                MaxAmount = 11173,
                Percentage = 18,
                RentClass = "125 - 168"

            },
            new IncomeScale
            {
                Id = 5,
                Scale = "$11174 - $13966",
                MinAmount = 11173.01,
                MaxAmount = 13966,
                Percentage = 21,
                RentClass = "195 - 224"

            },
            new IncomeScale
            {
                Id = 6,
                Scale = "$13967 - $16760",
                MinAmount = 13966.01,
                MaxAmount = 16760,
                Percentage = 24,
                RentClass = "279 - 335"

            },
            new IncomeScale
            {
                Id = 7,
                Scale = "$16761 - $19553",
                MinAmount = 67060.01,
                MaxAmount = 19553,
                Percentage = 27,
                RentClass = "377 - 440"
            },
            new IncomeScale
            {
                Id = 8,
                Scale = "$19554 - $22346",
                MinAmount = 19553.01,
                MaxAmount = 22346,
                Percentage = 30,
                RentClass = "488 - 559"
            },
            new IncomeScale
            {
                Id = 9,
                Scale = "> $22347",
                MinAmount = 22346.01,
                MaxAmount = 999999,
                Percentage = 30,
                RentClass = "> 559"
            }
        );
    }
    

    public static void SeedHouses(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<House>().HasData(
            new House
            {
                Id = 1,
                Code = "CODE-1",
                ItemCode = "ITEM-CODE-1",
                Address = "Kaya kaya 1",
                Type = HouseType.Vrijstaand,
                NumberOfBedrooms = 3,
                SquareMetersBvo = 100,
                SquareMetersGo = 95,
                SquareMetersFcb = 105,
                LandRegistryNumber = "LRN-1",
                ConstructionDate = new DateTime(1995, 1, 1),
                AppraisalDate = new DateTime(2005, 1, 1),
                RenovationDate = new DateTime(2000, 1, 1),
                MarketValue = 250000m,
                ConstructionCosts = 150000m,
                RenovationCosts = 15000m,
                GroundLease = null,
                RentBasePrice = 250m,
                RentBasePoints = 10,
                NeighborhoodId = 1,
                ComplexId = 1,
                CreatedById = 1
            },
            new House
            {
                Id = 2,
                Code = "CODE-2",
                ItemCode = "ITEM-CODE-2",
                Address = "Kaya kaya 2",
                Type = HouseType.Vrijstaand,
                NumberOfBedrooms = 5,
                SquareMetersBvo = 200,
                SquareMetersGo = 195,
                SquareMetersFcb = 205,
                LandRegistryNumber = "LRN-2",
                ConstructionDate = new DateTime(1995, 1, 1),
                AppraisalDate = new DateTime(2005, 1, 1),
                RenovationDate = new DateTime(2000, 1, 1),
                MarketValue = 350000m,
                ConstructionCosts = 250000m,
                RenovationCosts = 25000m,
                GroundLease = null,
                RentBasePrice = 450m,
                RentBasePoints = 30,
                NeighborhoodId = 2,
                ComplexId = 2,
                CreatedById = 1
            },
            new House
            {
                Id = 3,
                Code = "CODE-3",
                ItemCode = "ITEM-CODE-3",
                Address = "Kaya kaya 3",
                Type = HouseType.Vrijstaand,
                NumberOfBedrooms = 1,
                SquareMetersBvo = 50,
                SquareMetersGo = 45,
                SquareMetersFcb = 55,
                LandRegistryNumber = "LRN-3",
                ConstructionDate = new DateTime(1995, 1, 1),
                AppraisalDate = new DateTime(2005, 1, 1),
                RenovationDate = new DateTime(2000, 1, 1),
                MarketValue = 150000m,
                ConstructionCosts = 50000m,
                RenovationCosts = 5000m,
                GroundLease = null,
                RentBasePrice = 150m,
                RentBasePoints = 5,
                NeighborhoodId = 3,
                ComplexId = 3,
                CreatedById = 1
            }
        );
    }

    public static void SeedNeighborhoods(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Neighborhood>().HasData(
            new Neighborhood
            {
                Id = 1,
                Name = "Neighborhood 1",
                Valuation = 50,
                Points = 5,
                CreatedById = 1
            },
            new Neighborhood
            {
                Id = 2,
                Name = "Neighborhood 2",
                Valuation = 100,
                Points = 10,
                CreatedById = 1
            },
            new Neighborhood
            {
                Id = 3,
                Name = "Neighborhood 3",
                Valuation = 150,
                Points = 15,
                CreatedById = 1
            }
        );
    }

    public static void SeedComplexes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Complex>().HasData(
            new Complex
            {
                Id = 1,
                Code = "111111",
                Name = "Complex 1",
                ConstructionYear = 1988,
                CreatedById = 1
            },
            new Complex
            {
                Id = 2,
                Code = "222222",
                Name = "Complex 2",
                ConstructionYear = 2001,
                CreatedById = 1
            },
            new Complex
            {
                Id = 3,
                Code = "333333",
                Name = "Complex 3",
                ConstructionYear =  1995 , 
                CreatedById = 1
            }
        );
    }

    public static void SeedIncomes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Income>().HasData(
            new Income
            {
                Id = 1,
                Name = "Employer 1",
                Description = "Description 1",
                Amount = 500m,
                Type = IncomeType.Salary,
                Period = IncomePayPeriod.Monthly,
                StartDate = new DateTime(2020, 1, 1),
                PersonId = 1,
                CreatedById = 1
            },
            new Income
            {
                Id = 2,
                Name = "Employer 2",
                Description = "Description 2",
                Amount = 100m,
                Type = IncomeType.Salary,
                Period = IncomePayPeriod.Monthly,
                StartDate = new DateTime(2020, 1, 1),
                PersonId = 1,
                CreatedById = 1
            },
            new Income
            {
                Id = 3,
                Name = "Employer 3",
                Description = "Description 3",
                Amount = 300m,
                Type = IncomeType.Salary,
                Period = IncomePayPeriod.Fortnightly,
                StartDate = new DateTime(2020, 1, 1),
                PersonId = 2,
                CreatedById = 1
            },
            new Income
            {
                Id = 4,
                Name = "Employer 4",
                Description = "Description 4",
                Amount = 100m,
                Type = IncomeType.Salary,
                Period = IncomePayPeriod.Weekly,
                StartDate = new DateTime(2020, 1, 1),
                PersonId = 3,
                CreatedById = 1
            },
            new Income
            {
                Id = 5,
                Name = "Employer 5",
                Description = "Description 5",
                Amount = 250m,
                Type = IncomeType.Salary,
                Period = IncomePayPeriod.FourWeekly,
                StartDate = new DateTime(2020, 1, 1),
                PersonId = 4,
                CreatedById = 1
            }
        );
    }
}