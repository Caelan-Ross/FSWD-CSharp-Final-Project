using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MACK.Models
{
    public class Address
    {
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("address_id", TypeName = "int(10)")]
        public int AddressId { get; set; }

        [Required]
        [Column("street", TypeName = "varchar(128)")]
        public string Street { get; set; }

        [Required]
        [Column("city", TypeName = "varchar(128)")]
        public string City { get; set; }

        [Required]
        [Column("province", TypeName = "varchar(24)")]
        public string Province { get; set; }

        [Required]
        [Column("postal_code", TypeName = "varchar(6)")]
        [RegularExpression(@"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$", ErrorMessage = "Must be a valid postal code.")]
        public string PostalCode { get; set; }

        [Required]
        [Column("country", TypeName = "varchar(128)")] 
        public string Country { get; set; }

        [Required]
        [Column("dealership_id", TypeName = "int(10)")]
        public int? DealershipId { get; set; }

        [Required]
        [ForeignKey(nameof(DealershipId))]
        [InverseProperty(nameof(Models.Dealership.Address))]
        public virtual Dealership Dealership { get; set; }


    }
}

