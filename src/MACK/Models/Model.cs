using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int ManufacturerId { get; set; }

        // Navigation property
        public Manufacturer Manufacturer { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Series> Series { get; set; }

    }
}



