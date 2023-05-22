using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Net;

namespace MACK.Models
{
    public class Vehicle
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("vehicle_id", TypeName = "int(10)")]
        public int VehicleId { get; set; }

        [Required]
        [Column("vin", TypeName = "varchar(18)")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be exactly 17 characters long.")]
        [RegularExpression(@"^[A-Z0-9]*$", ErrorMessage = "Only Capitols and numbers allowed.")]
        public string VIN { get; set; }

        [Required]
        [Column("model_year", TypeName = "int(4)")]
        [Range(1900, 2050, ErrorMessage = "Model Year must be between 1900 and 2050")]
        public int Year { get; set; }

        [Required]
        [Column("manufacturer_id", TypeName = "int(10)")]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty(nameof(Models.Manufacturer.Vehicles))]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [Column("model_id", TypeName = "int(10)")]
        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        [InverseProperty(nameof(Models.Model.Vehicles))]
        public virtual Model Model { get; set; }

        [AllowNull]
        [Column("series_id", TypeName = "int(10)")]
        public int? SeriesId { get; set; }

        [ForeignKey(nameof(SeriesId))]
        [InverseProperty(nameof(Models.Series.Vehicles))]
        public virtual Series Series { get; set; }

        [Required]
        [Column("vehicle_type_id", TypeName = "int(10)")]
        public int VehicleTypeId { get; set; }

        [ForeignKey(nameof(VehicleTypeId))]
        [InverseProperty(nameof(Models.VehicleType.Vehicles))]
        public virtual VehicleType VehicleType { get; set; }

        [Required]
        [Column("engine_cylinder_count", TypeName = "int(2)")]
        public int EngineCylinderCount { get; set; }

        [Required]
        [Column("engine_displacement", TypeName = "varchar(128)")]
        public string EngineDisplacement { get; set; }

        [Required]
        [Column("engine", TypeName = "varchar(128)")]
        public string Engine { get; set; }

        [Required]
        [Column("fuel", TypeName = "varchar(128)")]
        public string Fuel { get; set; }

        [Required]
        [Column("transmission_id", TypeName = "int(10)")]
        public int TransmissionId { get; set; }

        [ForeignKey(nameof(TransmissionId))]
        [InverseProperty(nameof(Models.Transmission.Vehicles))]
        public virtual Transmission Transmission { get; set; }

        [Required]
        [Column("body_door_count", TypeName = "int(1)")]
        public int BodyDoorCount { get; set; }

        [Required]
        [Column("drivetrain_id", TypeName = "int(10)")]
        public int DrivetrainId { get; set; }

        [ForeignKey(nameof(DrivetrainId))]
        [InverseProperty(nameof(Models.Drivetrain.Vehicles))]
        public virtual Drivetrain Drivetrain { get; set; }

        [Required]
        [ForeignKey("exterior_colour_id")]
        public int ExteriorColourId { get; set; }

        [AllowNull]
        [ForeignKey(nameof(ExteriorColourId))]
        [InverseProperty(nameof(Colour.ExteriorVehicles))]
        public virtual Colour ExteriorColour { get; set; }

        [Required]
        [ForeignKey("interior_colour_id")]
        public int InteriorColourId { get; set; }

        [AllowNull]
        [ForeignKey(nameof(InteriorColourId))]
        [InverseProperty(nameof(Colour.InteriorVehicles))]
        public virtual Colour InteriorColour { get; set; }

        [Required]
        [Column("city_mpg", TypeName = "int(3)")]
        public int CityMPG { get; set; }

        [Required]
        [Column("highway_mpg", TypeName = "int(3)")]
        public int HighwayMPG { get; set; }

        [Required]
        [Column("weight")]
        public decimal Weight { get; set; }

        [Required]
        [Column("length")]
        public decimal Length { get; set; }

        [Required]
        [Column("width")]
        public decimal Width { get; set; }

        [Required]
        [Column("height")]
        public decimal Height { get; set; }


        [AllowNull]
        [InverseProperty(nameof(VehicleListing.Vehicle))]
        public ICollection<VehicleListing> VehicleListings { get; set; }


    }
}



