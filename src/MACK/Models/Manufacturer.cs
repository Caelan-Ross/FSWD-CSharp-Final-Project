using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        // Navigation property
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Model> Models { get; set; }

    }
}



