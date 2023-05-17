using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MACK.Models
{
    public class Series
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("series_id", TypeName = "int(10)")]
        public int SeriesId { get; set; }

        [Required]
        [Column("series_name", TypeName = "varchar(128)")]
        public string SeriesName { get; set; }

        [Required]
        [Column("model_id", TypeName = "int(10)")]
        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        [InverseProperty(nameof(Models.Model.Series))]
        public virtual Model Model { get; set; }

        [AllowNull]
        [InverseProperty(nameof(Vehicle.Series))]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}



