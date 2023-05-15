using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class Colour
    {
        public int ColourId
        {
            get;
            set;
        }
        public string ColourName
        {
            get;
            set;
        }

        // Navigation property
        public ICollection<Vehicle> VehiclesExterior { get; set; }
        public ICollection<Vehicle> VehiclesInterior { get; set; }
    }
}



