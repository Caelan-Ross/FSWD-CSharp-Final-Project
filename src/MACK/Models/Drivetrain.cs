using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace C_Sharp_Final_Project.Models
{
    public class Drivetrain
    {
        public int DrivetrainId { get; set; }
        public string DrivetrainType { get; set; }

        // Navigation property
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}



