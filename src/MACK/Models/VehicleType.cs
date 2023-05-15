using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string TypeName { get; set; }

        // Navigation property
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}



