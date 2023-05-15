using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class VehicleListing
    {
        [Key]
        public int ListingId { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public string VIN { get; set; }
        public Vehicle Vehicle { get; set; }

        public string StockNumber { get; set; }

        [Required]
        [ForeignKey("Condition")]
        public int ConditionId { get; set; }
        public Condition Condition { get; set; }

        public int Odometer { get; set; }
        public decimal MSRP { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime InventoryDate { get; set; }

        public bool Certified { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }

        public string PhotoUrlList { get; set; }

        [DataType(DataType.Date)]
        public DateTime PhotosLastModifiedDate { get; set; }

        public int Age { get; set; }
        public decimal Cost { get; set; }

        [Required]
        [ForeignKey("Dealership")]
        public int DealershipId { get; set; }
        public Dealership Dealership { get; set; }

        [DataType(DataType.Date)]
        public DateTime created_at { get; set; }

        [DataType(DataType.Date)]
        public DateTime updated_at { get; set; }

        [DataType(DataType.Date)]
        public DateTime deleted_at { get; set; }
    }
}



