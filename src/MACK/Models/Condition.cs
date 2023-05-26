using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MACK.Models
{
    public class Condition
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("condition_id", TypeName = "int(10)")]
        public int ConditionId { get; set; }

        [Required]
        [Column("condition_name", TypeName = "varchar(32)")]
        public string ConditionName { get; set; }

        [AllowNull]
        [InverseProperty(nameof(VehicleListing.Condition))]
        public virtual ICollection<VehicleListing> VehicleListings { get; set; }


    }
}



