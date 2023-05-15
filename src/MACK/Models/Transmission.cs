using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class Transmission
    {
        public int TransmissionId { get; set; }
        public string TransmissionType { get; set; }
        public int TransmissionGears { get; set; }

        // Navigation property
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}



