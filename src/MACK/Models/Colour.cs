using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace C_Sharp_Final_Project.Models
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



