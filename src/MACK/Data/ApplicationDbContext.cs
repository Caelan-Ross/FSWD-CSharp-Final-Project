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
        public DbSet<Manufacturer> Manufacturers { get; set; }
        
        public DbSet<Model> Models { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        /************************
         *      CONNECTION       *
         ************************/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If context is not already configured;
            if (!optionsBuilder.IsConfigured)
            {
                // Specify the connection to the database
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=exsm3943-project-mack ", new MySqlServerVersion(new Version(10, 10, 3)));
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

            modelBuilder.Entity<Vehicle>()
                .HasData(
                    new Vehicle
                    {
                        VehicleId = -1,
                        VIN = "11111111111111111",
                        Year = 2000,
                        Fuel = "TestFuel",
                        ExteriorColour = "ExtTest",
                        InteriorColour = "IntTest",
                        BodyDoorCount = 1,
                        IsAutomatic = true,
                        IsUsed = true,
                        Features = "Test features",
                        Description = "Test description",
                        ModelId = -1,
                        StockNumber = "A1",
                        Price = 0.1
                    }
                );
        }
    }
}



