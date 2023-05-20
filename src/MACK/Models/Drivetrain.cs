using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MACK.Models
{
    public class Drivetrain
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("drivetrain_id", TypeName = "int(10)")]
        public int DrivetrainId { get; set; }

        [Required]
        [Column("drivetrain_type", TypeName = "varchar(128)")]
        public string DrivetrainType { get; set; }

        // Name and type
        [Column("vehicle_id", TypeName = "int(10)")]
        // Cannot be Null
        [Required]
        public int VehicleId { get; set; }

        [AllowNull]
        [InverseProperty(nameof(Vehicle.Drivetrain))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }
}



