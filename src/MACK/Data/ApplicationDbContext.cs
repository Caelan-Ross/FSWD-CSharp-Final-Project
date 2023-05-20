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
        }
    }
}



