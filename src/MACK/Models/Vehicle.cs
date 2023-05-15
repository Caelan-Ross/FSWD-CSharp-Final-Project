using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Net;

namespace C_Sharp_Final_Project.Models
{
    public class Vehicle
    {
        public string VIN { get; set; }
        public int Year { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int? SeriesId { get; set; }
        public Series Series { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public int EngineCylinderCount { get; set; }
        public string EngineDisplacement { get; set; }
        public string Engine { get; set; }
        public string Fuel { get; set; }
        public int TransmissionId { get; set; }
        public Transmission Transmission { get; set; }
        public int BodyDoorCount { get; set; }
        public int DrivetrainId { get; set; }
        public Drivetrain Drivetrain { get; set; }
        public int ExteriorColourId { get; set; }
        public Colour ExteriorColour { get; set; }
        public int InteriorColourId { get; set; }
        public Colour InteriorColour { get; set; }
        public int CityMPG { get; set; }
        public int HighwayMPG { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public ICollection<VehicleListing> VehicleListings { get; set; }


    }
}



