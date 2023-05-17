﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [Column("vehicle_listing_id", TypeName = "int(10)")]
        public int VehicleListingId { get; set; }

        [ForeignKey(nameof(VehicleListingId))]
        [InverseProperty(nameof(VehicleListing.Condition))]
        public virtual VehicleListing VehicleListings { get; set; }

    }
}



