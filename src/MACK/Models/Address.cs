using System;
using System.ComponentModel.DataAnnotations;

namespace C_Sharp_Final_Project.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        public ICollection<Dealership> Dealerships { get; set; }

    }
}

