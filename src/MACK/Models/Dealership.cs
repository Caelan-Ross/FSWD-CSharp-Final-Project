using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class Dealership
    {
        [Key]
        public int DealershipId { get; set; }

        [Required]
        [ForeignKey("Corporation")]
        public int CorporationId { get; set; }

        [Required]
        public string DealershipName { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Corporation Corporation { get; set; }
        public Address Address { get; set; }

        public ICollection<VehicleListing> VehicleListings { get; set; }

    }
}

