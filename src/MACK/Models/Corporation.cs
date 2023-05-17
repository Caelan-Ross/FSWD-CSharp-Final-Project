using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MACK.Models
{
    public class Corporation
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("corporation_id", TypeName = "int(10)")]
        public int CorporationId { get; set; }

        [Required]
        [Column("corporation_name", TypeName = "varchar(32)")]
        public string CorporationName { get; set; }

        [Required]
        [Column("address_id", TypeName = "int(10)")]
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty(nameof(Models.Address.Corperation))]
        public virtual Address Address { get; set; }

        [AllowNull]
        [InverseProperty(nameof(Dealership.Corporation))]
        public ICollection<Dealership> Dealerships { get; set; }

    }
}



