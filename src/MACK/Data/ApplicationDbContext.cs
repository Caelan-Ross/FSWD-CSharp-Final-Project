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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Order Dbset from child table to parent table
        public DbSet<Corporation> Corporations
        {
            get;
            set;
        }
        public DbSet<Dealership> Dealerships
        {
            get;
            set;
        }
        public DbSet<Address> Addresses
        {
            get; 
            set;
        }
        public DbSet<Vehicle> Vehicles
        {
            get;
            set;
        }
        public DbSet<VehicleListing> VehicleListings
        {
            get;
            set;
        }
        public DbSet<Manufacturer> Manufacturers
        {
            get;
            set;
        }
        public DbSet<Model> Models
        {
            get;
            set;
        }
        public DbSet<Series> Series
        {
            get;
            set;
        }
        public DbSet<VehicleType> VehicleTypes
        {
            get;
            set;
        }
        public DbSet<Condition> Conditions
        {
            get;
            set;
        }
        public DbSet<Transmission> Transmissions
        {
            get;
            set;
        }
        public DbSet<Drivetrain> Drivetrains
        {
            get;
            set;
        }
        public DbSet<Colour> Colours
        {
            get;
            set;
        }

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

            // Configure Corporation
            modelBuilder.Entity<Corporation>()
                .HasKey(c => c.CorporationId); // Primary Key

            modelBuilder.Entity<Corporation>()
                .HasIndex(c => c.CorporationName)
                .IsUnique(); // Unique Constraint for CorporationName

            modelBuilder.Entity<Corporation>()
                .HasOne(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressId); // Foreign Key constraint for AddressId

            modelBuilder.Entity<Corporation>()
                .Property(c => c.CorporationName)
                .IsRequired() // Data Validation: CorporationName is required
                .HasMaxLength(100);

            // Seed data for Corporation
            modelBuilder.Entity<Corporation>().HasData(
              new Corporation
              {
                  CorporationId = 1,
                  CorporationName = "AutoGroup Inc.",
                  AddressId = 1
              }
            );

            // Configure Address
            modelBuilder.Entity<Address>()
                .HasKey(a => a.AddressId); // Primary Key

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired() // Data Validation: Street is required
                .HasMaxLength(100); // Data Validation: Street cannot exceed 100 characters

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired() // Data Validation: City is required
                .HasMaxLength(100); // Data Validation: City cannot exceed 100 characters

            modelBuilder.Entity<Address>()
                .Property(a => a.Province)
                .IsRequired() // Data Validation: Province is required
                .HasMaxLength(100); // Data Validation: Province cannot exceed 100 characters

            modelBuilder.Entity<Address>()
                .Property(a => a.PostalCode)
                .IsRequired() // Data Validation: PostalCode is required
                .HasMaxLength(10); // Data Validation: PostalCode cannot exceed 10 characters

            modelBuilder.Entity<Address>()
                .Property(a => a.Country)
                .IsRequired() // Data Validation: Country is required
                .HasMaxLength(2);

            // Seed data for Address
            modelBuilder.Entity<Address>().HasData(
              new Address
              {
                  AddressId = 1,
                  Street = "123 Main Street",
                  City = "Prince Albert",
                  Province = "Saskatchewan",
                  PostalCode = "S6V-2X1",
                  Country = "CA"
              },
              new Address
              {
                  AddressId = 2,
                  Street = "456 Secondary Road",
                  City = "Prince Albert",
                  Province = "Saskatchewan",
                  PostalCode = "S6V-3Y2",
                  Country = "CA"
              }
            );


            // Configure Dealership
            modelBuilder.Entity<Dealership>()
                .HasKey(d => d.DealershipId); // Primary Key

            modelBuilder.Entity<Dealership>()
                .HasOne(d => d.Corporation)
                .WithMany()
                .HasForeignKey(d => d.CorporationId); // Foreign Key constraint

            modelBuilder.Entity<Dealership>()
                .HasOne(d => d.Address)
                .WithMany()
                .HasForeignKey(d => d.AddressId); // Foreign Key constraint

            modelBuilder.Entity<Dealership>()
                .Property(d => d.DealershipName)
                .IsRequired() // Data Validation: DealershipName is required
                .HasMaxLength(100); // Data Validation: DealershipName cannot exceed 100 characters

            // Seed data for Dealership
            modelBuilder.Entity<Dealership>().HasData(
                new Dealership
                {
                    DealershipId = 1,
                    CorporationId = 1,
                    DealershipName = "Lakeland Ford",
                    AddressId = 2
                }
            );



            modelBuilder.Entity<Manufacturer>(entity =>
            {
                // Primary Key
                entity.HasKey(m => m.ManufacturerId);

                // Properties
                entity.Property(m => m.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(100);  // assuming a maximum length of 100

                // Unique Constraint
                entity.HasIndex(m => m.ManufacturerName).IsUnique();

                // Relationships
                entity.HasMany(m => m.Vehicles)
                    .WithOne(v => v.Manufacturer)
                    .HasForeignKey(v => v.ManufacturerId);
            });

            // Seed data for Manufacturer
            modelBuilder.Entity<Manufacturer>().HasData(
              new Manufacturer
              {
                  ManufacturerId = 1,
                  ManufacturerName = "Honda"
              }
            );

            modelBuilder.Entity<Model>(entity =>
            {
                // Primary Key
                entity.HasKey(m => m.ModelId);

                // Properties
                entity.Property(m => m.ModelName)
                    .IsRequired()
                    .HasMaxLength(100);  // assuming a maximum length of 100

                // Unique Constraint
                entity.HasIndex(m => new { m.ModelName, m.ManufacturerId }).IsUnique();

                // Relationships
                entity.HasOne(m => m.Manufacturer)
                    .WithMany(man => man.Models)
                    .HasForeignKey(m => m.ManufacturerId);
            });

            // Seed data for Model
            modelBuilder.Entity<Model>().HasData(
              new Model
              {
                  ModelId = 1,
                  ModelName = "Accord",
                  ManufacturerId = 1
              }
            );

            modelBuilder.Entity<Series>(entity =>
            {
                // Primary Key
                entity.HasKey(s => s.SeriesId);

                // Properties
                entity.Property(s => s.SeriesName)
                    .IsRequired()
                    .HasMaxLength(100);  // assuming a maximum length of 100

                // Unique Constraint
                entity.HasIndex(s => new { s.SeriesName, s.ModelId }).IsUnique();

                // Relationships
                entity.HasOne(s => s.Model)
                    .WithMany(m => m.Series)
                    .HasForeignKey(s => s.ModelId);
            });

            // Seed data for Series
            modelBuilder.Entity<Series>().HasData(
              new Series
              {
                  SeriesId = 1,
                  SeriesName = "LX",
                  ModelId = 1
              }
            );

            modelBuilder.Entity<VehicleType>(entity =>
            {
                // Primary Key
                entity.HasKey(vt => vt.VehicleTypeId);

                // Properties
                entity.Property(vt => vt.TypeName)
                    .IsRequired()
                    .HasMaxLength(100);  // assuming a maximum length of 100

                // Unique Constraint
                entity.HasIndex(vt => vt.TypeName).IsUnique();

                // Relationships
                entity.HasMany(vt => vt.Vehicles)
                    .WithOne(v => v.VehicleType)
                    .HasForeignKey(v => v.VehicleTypeId);
            });

            // Seed data for VehicleType
            modelBuilder.Entity<VehicleType>().HasData(
              new VehicleType
              {
                  VehicleTypeId = 1,
                  TypeName = "Sedan"
              }
            );

            modelBuilder.Entity<Condition>(entity =>
            {
                // Primary Key
                entity.HasKey(c => c.ConditionId);

                // Properties
                entity.Property(c => c.ConditionName)
                    .IsRequired()
                    .HasMaxLength(100);  // assuming a maximum length of 100

                // Unique Constraint
                entity.HasIndex(c => c.ConditionName).IsUnique();

                // Relationships
                entity.HasMany(c => c.VehicleListings)
                    .WithOne(vl => vl.Condition)
                    .HasForeignKey(vl => vl.ConditionId);
            });

            // Seed data for Condition
            modelBuilder.Entity<Condition>().HasData(
              new Condition
              {
                  ConditionId = 1,
                  ConditionName = "Used"
              }
            );

            modelBuilder.Entity<Transmission>(entity =>
            {
                // Primary Key
                entity.HasKey(t => t.TransmissionId);

                // Properties
                entity.Property(t => t.TransmissionType)
                    .IsRequired()
                    .HasMaxLength(50);  // assuming a maximum length of 50

                entity.Property(t => t.TransmissionGears);

                // Unique Constraint
                entity.HasIndex(t => t.TransmissionType).IsUnique();

                // Relationships
                entity.HasMany(t => t.Vehicles)
                    .WithOne(v => v.Transmission)
                    .HasForeignKey(v => v.TransmissionId);
            });

            // Seed data for Transmission
            modelBuilder.Entity<Transmission>().HasData(
              new Transmission
              {
                  TransmissionId = 1,
                  TransmissionType = "Automatic",
                  TransmissionGears = 6
              }
            );

            modelBuilder.Entity<Drivetrain>(entity =>
            {
                // Primary Key
                entity.HasKey(d => d.DrivetrainId);

                // Properties
                entity.Property(d => d.DrivetrainType)
                    .IsRequired()
                    .HasMaxLength(50);  // assuming a maximum length of 50

                // Unique Constraint
                entity.HasIndex(d => d.DrivetrainType).IsUnique();

                // Relationships
                entity.HasMany(d => d.Vehicles)
                    .WithOne(v => v.Drivetrain)
                    .HasForeignKey(v => v.DrivetrainId);
            });

            // Seed data for Drivetrain
            modelBuilder.Entity<Drivetrain>().HasData(
              new Drivetrain
              {
                  DrivetrainId = 1,
                  DrivetrainType = "FWD"
              }
            );

            modelBuilder.Entity<Colour>(entity =>
            {
                // Primary Key
                entity.HasKey(c => c.ColourId);

                // Properties
                entity.Property(c => c.ColourName)
                    .IsRequired()
                    .HasMaxLength(50); // assuming a maximum length of 50

                // Unique Constraint
                entity.HasIndex(c => c.ColourName).IsUnique();

                // Relationships
                entity.HasMany(c => c.VehiclesExterior)
                    .WithOne(v => v.ExteriorColour)
                    .HasForeignKey(v => v.ExteriorColourId);

                entity.HasMany(c => c.VehiclesInterior)
                    .WithOne(v => v.InteriorColour)
                    .HasForeignKey(v => v.InteriorColourId);
            });

            // Seed data for Colour
            modelBuilder.Entity<Colour>().HasData(
              new Colour
              {
                  ColourId = 1,
                  ColourName = "Red"
              },
              new Colour
              {
                  ColourId = 2,
                  ColourName = "Black"
              }
            );

            // Configure Vehicle
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.VIN); // Primary Key

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.VIN) // Index on VIN
                .IsUnique(); // VIN must be unique

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.VIN)
                .IsRequired() // Data Validation: VIN is required
                .HasMaxLength(17); // Data Validation: VIN cannot exceed 17 characters

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.EngineDisplacement)
                .HasMaxLength(10); // Data Validation: EngineDisplacement cannot exceed 10 characters

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Engine)
                .HasMaxLength(50); // Data Validation: Engine cannot exceed 50 characters

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Fuel)
                .HasMaxLength(50);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Manufacturer)
                .WithMany(m => m.Vehicles)
                .HasForeignKey(v => v.ManufacturerId)
                .IsRequired(); // ManufacturerId is required

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Model)
                .WithMany(m => m.Vehicles)
                .HasForeignKey(v => v.ModelId)
                .IsRequired(); // ModelId is required

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Series)
                .WithMany(s => s.Vehicles)
                .HasForeignKey(v => v.SeriesId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleType)
                .WithMany(vt => vt.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId)
                .IsRequired(); // VehicleTypeId is required

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Transmission)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(v => v.TransmissionId); // TransmissionId is not marked as required

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Drivetrain)
                .WithMany(d => d.Vehicles)
                .HasForeignKey(v => v.DrivetrainId); // DrivetrainId is not marked as required

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.ExteriorColour)
                .WithMany(ec => ec.VehiclesExterior)
                .HasForeignKey(v => v.ExteriorColourId); // ExteriorColourId is not marked as required

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.InteriorColour)
                .WithMany(ic => ic.VehiclesInterior)
                .HasForeignKey(v => v.InteriorColourId);

            // Seed data for Vehicle
            modelBuilder.Entity<Vehicle>().HasData(
              new Vehicle
              {
                  VIN = "1HGCM82633A123456",
                  Year = 2020,
                  ManufacturerId = 1,
                  ModelId = 1,
                  SeriesId = 1,
                  VehicleTypeId = 1,
                  EngineCylinderCount = 6,
                  EngineDisplacement = "3.5L",
                  Engine = "V6",
                  Fuel = "Gasoline",
                  TransmissionId = 1,
                  BodyDoorCount = 4,
                  DrivetrainId = 1,
                  ExteriorColourId = 1,
                  InteriorColourId = 2,
                  CityMPG = 25,
                  HighwayMPG = 35,
                  Weight = 1500,
                  Length = 190.9M,
                  Width = 73.9M,
                  Height = 57.1M
              }
            );

            modelBuilder.Entity<VehicleListing>(entity =>
            {
                // Primary Key
                entity.HasKey(vl => vl.ListingId);

                // Properties
                entity.Property(vl => vl.StockNumber).IsRequired();
                entity.Property(vl => vl.MSRP).HasColumnType("decimal(18,2)");
                entity.Property(vl => vl.Price).HasColumnType("decimal(18,2)");
                entity.Property(vl => vl.Cost).HasColumnType("decimal(18,2)");

                // Relationships
                entity.HasOne(vl => vl.Vehicle)
                    .WithMany(v => v.VehicleListings)
                    .HasForeignKey(vl => vl.VIN);

                entity.HasOne(vl => vl.Condition)
                    .WithMany(c => c.VehicleListings)
                    .HasForeignKey(vl => vl.ConditionId);

                entity.HasOne(vl => vl.Dealership)
                    .WithMany(d => d.VehicleListings)
                    .HasForeignKey(vl => vl.DealershipId);

                // Unique Constraint
                entity.HasIndex(vl => new { vl.StockNumber, vl.DealershipId }).IsUnique();
            });

            // Seed data for VehicleListing
            modelBuilder.Entity<VehicleListing>().HasData(
              new VehicleListing
              {
                  ListingId = 1,
                  VIN = "1HGCM82633A123456",
                  StockNumber = "AG123",
                  ConditionId = 1,
                  Odometer = 5000,
                  MSRP = 25000,
                  Price = 24000,
                  InventoryDate = DateTime.Now,
                  Certified = true,
                  Description = "Excellent condition, low mileage",
                  Features = "Leather seats, sunroof, navigation system",
                  PhotoUrlList = "www.example.com/photo1.jpg,www.example.com/photo2.jpg",
                  PhotosLastModifiedDate = DateTime.Now,
                  Age = 3,
                  Cost = 20000,
                  DealershipId = 1,
                  created_at = DateTime.Now
              }
            );
        }
    }
}



