using MACK.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MACK
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Order Dbset from child table to parent table
        public DbSet<Corporation> Corporations{ get; set; }

        public DbSet<Dealership> Dealerships { get; set; }
        
        public DbSet<Address> Addresses { get; set; }
        
        public DbSet<Vehicle> Vehicles { get; set; }
        
        public DbSet<VehicleListing> VehicleListings { get; set; }
       
        public DbSet<Manufacturer> Manufacturers { get; set; }
        
        public DbSet<Model> Models { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<Transmission> Transmissions { get; set; }

        public DbSet<Drivetrain> Drivetrains { get; set; }

        public DbSet<Colour> Colours { get; set; }

        /************************
         *      CONNECTION       *
         ************************/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If context is not already configured;
            if (!optionsBuilder.IsConfigured)
            {
                // Specify the connection to the database
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=mack", new MySqlServerVersion(new Version(10, 10, 3)));
            }
        }

        /************************
         *      ENTITIES         *
         ************************/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure primary key for IdentityUserLogin<string>
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(x => new { x.LoginProvider, x.ProviderKey });

            modelBuilder.Entity<Address>()
                .HasData(
                    new Address
                    {
                        AddressId = -1,
                        Street = "123 Street",
                        City = "Edmonton",
                        Province = "Alberta",
                        PostalCode = "A1A1A1",
                        Country = "Canada",
                        DealershipId = -1
                    }
                );

            modelBuilder.Entity<Colour>()
                .HasData(
                    new Colour
                    {
                        ColourId = -1,
                        ColourName = "Blue",
                        VehicleId = -1
                    }
                );

            modelBuilder.Entity<Condition>()
                .HasData(
                    new Condition
                    {
                        ConditionId = -1,
                        ConditionName = "Used",
                    }
                );

            modelBuilder.Entity<Corporation>()
                .HasData(
                    new Corporation
                    {
                        CorporationId = -1,
                        CorporationName = "TestCorporation"
                    }
                );

            modelBuilder.Entity<Dealership>()
                .HasData(
                    new Dealership
                    {
                        DealershipId = -1,
                        DealershipName = "TestDealership",
                        CorporationId= -1,
                        AddressId = -1
                    }
                );

            modelBuilder.Entity<Drivetrain>()
                .HasData(
                    new Drivetrain
                    {
                        DrivetrainId = -1,
                        DrivetrainType = "TestDrivetrain",
                        VehicleId= -1
                    }
                );

            modelBuilder.Entity<Manufacturer>()
                .HasData(
                    new Manufacturer
                    {
                        ManufacturerId = -1,
                        ManufacturerName = "TestManufacturer"
                    }
                );

            modelBuilder.Entity<Model>()
                .HasData(
                    new Model
                    {
                        ModelId = -1,
                        ModelName = "TestModel",
                        ManufacturerId= -1
                    }
                );

            modelBuilder.Entity<Series>()
                .HasData(
                    new Series
                    {
                        SeriesId = -1,
                        SeriesName = "TestSeries",
                        ModelId= -1
                    }
                );

            modelBuilder.Entity<Transmission>()
                .HasData(
                    new Transmission
                    {
                        TransmissionId = -1,
                        TransmissionType = "TestType",
                        TransmissionGears = 1
                    }
                );

            modelBuilder.Entity<Vehicle>()
                .HasData(
                    new Vehicle
                    {
                        VehicleId = -1,
                        VIN = "11111111111111111",
                        Year = 2000,
                        SeriesId = -1,
                        VehicleTypeId = -1,
                        EngineCylinderCount = 1,
                        EngineDisplacement = "TestDisplacment",
                        Engine = "TestEngine",
                        Fuel = "TestFuel",
                        TransmissionId= -1,
                        BodyDoorCount = 1,
                        DrivetrainId = -1,
                        ExteriorColourId = -1,
                        InteriorColourId = -1,
                        CityMPG = 1,
                        HighwayMPG = 1,
                        Weight = 1,
                        Length = 1,
                        Width = 1,
                        Height = 1
                    }
                );

            modelBuilder.Entity<VehicleListing>()
                .HasData(
                    new VehicleListing
                    {
                        ListingId = -1,
                        VIN = "11111111111111111",
                        StockNumber = "Test",
                        Odometer = 1,
                        MSRP = 1,
                        Price = 1,
                        InventoryDate = DateTime.Now,
                        Certified = true,
                        Description = "TestDescription",
                        Features = "TestFeatures",
                        PhotoUrlList = "TestPhotoList",
                        PhotosLastModifiedDate = DateTime.Now,
                        Age = 1,
                        Cost = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        DeletedAt = DateTime.Now,
                        VehicleId = -1,
                        DealershipId = -1,
                        ConditionId = -1
                    }
                );

            modelBuilder.Entity<VehicleType>()
                .HasData(
                    new VehicleType
                    {
                        VehicleTypeId = -1,
                        TypeName = "TestType"
                    }
                );
        }
    }
}



