using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MACK.Models
{
    public class Colour
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("colour_id", TypeName = "int(10)")]
        public int ColourId { get; set; }

        [Required]
        [Column("colour_name", TypeName = "varchar(32)")]
        public string ColourName { get; set; }

        [Required]
        [Column("vehicle_id", TypeName = "int(10)")]
        public int VehicleId { get; set; }

        [AllowNull]
        [InverseProperty(nameof(Vehicle.ExteriorColour))]
        public virtual ICollection<Vehicle> ExteriorVehicles { get; set; }

        [AllowNull]
        [InverseProperty(nameof(Vehicle.InteriorColour))]
        public virtual ICollection<Vehicle> InteriorVehicles { get; set; }
    }
}



