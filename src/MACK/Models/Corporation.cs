using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class Corporation
    {
        [Key]
        public int CorporationId { get; set; }

        [Required]
        public string CorporationName { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        public ICollection<Dealership> Dealerships { get; set; }

    }
}



