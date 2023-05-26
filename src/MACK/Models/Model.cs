using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MACK.Models
{
    public class Model
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("model_id", TypeName = "int(10)")]
        public int ModelId { get; set; }

        [Required]
        [Column("model_name", TypeName = "varchar(128)")]
        public string ModelName { get; set; }

        [Required]
        [Column("manufacturer_id", TypeName = "int(10)")]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty(nameof(Models.Manufacturer.Models))]
        public virtual Manufacturer Manufacturer { get; set; }

        [AllowNull]
        [InverseProperty(nameof(Models.Series.Model))]
        public ICollection<Series> Series { get; set; }

    }
}



