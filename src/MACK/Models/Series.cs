using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class Series
    {
        public int SeriesId { get; set; }
        public string SeriesName { get; set; }
        public int ModelId { get; set; }

        // Navigation property
        public Model Model { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}



