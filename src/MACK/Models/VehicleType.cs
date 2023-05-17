using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MACK.Models
{
    public class VehicleType
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("vehicle_type_id", TypeName = "int(10)")]
        public int VehicleTypeId { get; set; }

        [Required]
        [Column("type_name", TypeName = "varchar(128)")]
        public string TypeName { get; set; }

        [AllowNull]
        [InverseProperty(nameof(Vehicle.VehicleType))]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}



