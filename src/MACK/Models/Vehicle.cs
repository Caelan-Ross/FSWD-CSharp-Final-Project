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
        [Column("price")]
        public double Price { get; set; }

        [Required]
        [Column("stock_number", TypeName = "varchar(24)")]
        public string StockNumber { get; set; }

        [Required]
        [Column("fuel", TypeName = "varchar(128)")]
        public string Fuel { get; set; }

        [Required]
        [Column("exterior_colour", TypeName = "varchar(128)")]
        public string ExteriorColour { get; set; }

        [Required]
        [Column("interior_colour", TypeName = "varchar(128)")]
        public string InteriorColour { get; set; }

        [Required]
        [Column("body_door_count", TypeName = "int(1)")]
        public int BodyDoorCount { get; set; }

        [Required]
        [Column("features", TypeName = "varchar(128)")]
        public string Features { get; set; }

        [Required]
        [Column("description", TypeName = "varchar(128)")]
        public string Description { get; set; }

        [Required]
        [Column("is_used")]
        public bool IsUsed { get; set; }

        [Required]
        [Column("is_automatic")]
        public bool IsAutomatic { get; set; }

        [Required]
        [Column("model_id")]
        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        [InverseProperty(nameof(Models.Model.Vehicles))]
        public virtual Model Model { get; set; }

    }
}



