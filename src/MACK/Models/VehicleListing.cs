using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class VehicleListing
    {
        //Primary Key
        [Key]
        // Auto incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Name and type
        [Column("listing_id", TypeName = "int(10)")]
        public int ListingId { get; set; }

        [Required]
        [Column("vin", TypeName = "varchar(18)")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be exactly 17 characters long.")]
        [RegularExpression(@"^[A-Z0-9]*$", ErrorMessage = "Only Capitols and numbers allowed.")]
        public string VIN { get; set; }

        [Required]
        [Column("stock_number", TypeName = "int(5)")]
        public int StockNumber { get; set; }

        [Required]
        [Column("odometer", TypeName = "int(7)")]
        public int Odometer { get; set; }

        [Required]
        [Column("msrp", TypeName = "int(7)")]
        public decimal MSRP { get; set; }

        [Required]
        [Column("price", TypeName = "int(7)")]
        public decimal Price { get; set; }

        [Required]
        [Column("inventory_date")]
        public DateTime InventoryDate { get; set; }

        [Required]
        [Column("certified")]
        public bool Certified { get; set; }

        [Required]
        [Column("description", TypeName = "varchar(1024)")]
        public string Description { get; set; }

        [Required]
        [Column("features", TypeName = "varchar(512)")]
        public string Features { get; set; }

        [Required]
        [Column("photo_url_list", TypeName = "varchar(1024)")]
        public string PhotoUrlList { get; set; }

        [Required]
        [Column("photos_last_modified_date")]
        public DateTime PhotosLastModifiedDate { get; set; }

        [Required]
        [Column("age", TypeName = "int(3)")]
        public int Age { get; set; }

        [Required]
        [Column("cost")]
        public decimal Cost { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [Column("deleted_at")]
        public DateTime DeletedAt { get; set; }

        [Required]
        [Column("vehicle_id", TypeName = "int(10)")]
        public int VehicleId { get; set; }

        [Required]
        [Column("dealership_id", TypeName = "int(10)")]
        public int DealershipId { get; set; }

        [Required]
        [Column("condition_id", TypeName = "int(10)")]
        public int ConditionId { get; set; }

        [ForeignKey(nameof(ConditionId))]
        [InverseProperty(nameof(Models.Condition.VehicleListings))]
        public virtual Condition Condition { get; set; }

        [ForeignKey(nameof(DealershipId))]
        [InverseProperty(nameof(Models.Dealership.VehicleListings))]
        public virtual Dealership Dealership { get; set; }

        [ForeignKey(nameof(VehicleId))]
        [InverseProperty(nameof(Models.Vehicle.VehicleListings))]
        public virtual Vehicle Vehicle { get; set; }
    }
}



