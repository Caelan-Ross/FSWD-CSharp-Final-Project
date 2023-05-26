using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MACK.Models
{
    public class Manufacturer
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("manufacturer_id", TypeName = "int(10)")]
        public int ManufacturerId { get; set; }

        [Required]
        [Column("manufacturer_name", TypeName = "varchar(128)")]
        public string ManufacturerName { get; set; }

        [AllowNull]
        [InverseProperty(nameof(Model.Manufacturer))]
        public ICollection<Model> Models { get; set; }

    }
}



