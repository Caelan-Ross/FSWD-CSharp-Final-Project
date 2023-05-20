using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class Dealership
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("dealership_id", TypeName = "int(10)")]
        public int DealershipId { get; set; }

        [Required]
        [Column("dealership_name", TypeName = "varchar(128)")]
        public string DealershipName { get; set; }

        [Required]
        [Column("corperation_id", TypeName = "int(10)")]
        public int CorporationId { get; set; }

        [Required]
        [Column("address_id", TypeName = "int(10)")]
        public int AddressId { get; set; }

        [Required]
        [ForeignKey(nameof(CorporationId))]
        [InverseProperty(nameof(Models.Corporation.Dealerships))]
        public virtual Corporation Corporation { get; set; }

        [Required]
        [InverseProperty(nameof(Models.Address.Dealership))]
        public virtual Address Address { get; set; }

        [Required]
        [InverseProperty(nameof(VehicleListing.Dealership))]
        public ICollection<VehicleListing> VehicleListings { get; set; }

    }
}

