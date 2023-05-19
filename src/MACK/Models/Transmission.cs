using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MACK.Models
{
    public class Transmission
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("transmission_id", TypeName = "int(10)")]
        public int TransmissionId { get; set; }

        [Required]
        [Column("transmission_type", TypeName = "varchar(128)")]
        public string TransmissionType { get; set; }

        [Required]
        [Column("transmission_gears", TypeName = "int(3)")]
        public int TransmissionGears { get; set; }

        [AllowNull]
        [InverseProperty(nameof(Vehicle.Transmission))]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}



