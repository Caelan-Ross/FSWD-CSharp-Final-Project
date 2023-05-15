using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MACK.Models
{
    public class Condition
    {
        public int ConditionId { get; set; }
        public string ConditionName { get; set; }

        public ICollection<VehicleListing> VehicleListings { get; set; }

    }
}



