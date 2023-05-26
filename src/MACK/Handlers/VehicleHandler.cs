using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Handlers
{
    public static class VehicleHandlers
    {
        // Create
        public static Vehicle CreateVehicle(string vin, int year, int? seriesId,
            int vehicleTypeId, int engineCylinderCount, string engineDisplacement, string engine, string fuel,
            int transmissionId, int bodyDoorCount, int drivetrainId, int exteriorColourId, int interiorColourId,
            int cityMpg, int highwayMpg, decimal weight, decimal length, decimal width, decimal height)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Vehicle vehicle = new Vehicle
                {
                    VIN = vin,
                    Year = year,
                    SeriesId = seriesId,
                    VehicleTypeId = vehicleTypeId,
                    EngineCylinderCount = engineCylinderCount,
                    EngineDisplacement = engineDisplacement,
                    Engine = engine,
                    Fuel = fuel,
                    TransmissionId = transmissionId,
                    BodyDoorCount = bodyDoorCount,
                    DrivetrainId = drivetrainId,
                    ExteriorColourId = exteriorColourId,
                    InteriorColourId = interiorColourId,
                    CityMPG = cityMpg,
                    HighwayMPG = highwayMpg,
                    Weight = weight,
                    Length = length,
                    Width = width,
                    Height = height
                };
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();

                return vehicle;
            }
        }

        // Read (Single)
        public static Vehicle GetVehicleById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Vehicle vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleId == id);
                return vehicle;
            }
        }

        // Read (All)
        public static List<Vehicle> GetAllVehicles()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Vehicle> vehicles = _context.Vehicles.ToList();
                return vehicles;
            }
        }

        // Update
        public static Vehicle UpdateVehicle(Vehicle vehicle)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Vehicle existingVehicle = _context.Vehicles.Find(vehicle.VehicleId);
                if(existingVehicle == null)
                {
                    return existingVehicle;
                }

                existingVehicle.VIN = vehicle.VIN;
                existingVehicle.Year = vehicle.Year;
                existingVehicle.SeriesId = vehicle.SeriesId;
                existingVehicle.VehicleTypeId = vehicle.VehicleTypeId;
                existingVehicle.EngineCylinderCount = vehicle.EngineCylinderCount;
                existingVehicle.EngineDisplacement = vehicle.EngineDisplacement;
                existingVehicle.Engine = vehicle.Engine;
                existingVehicle.Fuel = vehicle.Fuel;
                existingVehicle.TransmissionId = vehicle.TransmissionId;
                existingVehicle.BodyDoorCount = vehicle.BodyDoorCount;
                existingVehicle.DrivetrainId = vehicle.DrivetrainId;
                existingVehicle.ExteriorColourId = vehicle.ExteriorColourId;
                existingVehicle.InteriorColourId = vehicle.InteriorColourId;
                existingVehicle.CityMPG = vehicle.CityMPG;
                existingVehicle.HighwayMPG = vehicle.HighwayMPG;
                existingVehicle.Weight = vehicle.Weight;
                existingVehicle.Length = vehicle.Length;
                existingVehicle.Width = vehicle.Width;
                existingVehicle.Height = vehicle.Height;

                _context.SaveChanges();

                return existingVehicle;
            }
        }

        // Delete
        public static void DeleteVehicle(Vehicle vehicle)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Vehicle existingVehicle = _context.Vehicles.Find(vehicle.VehicleId);
                if(existingVehicle == null)
                {
                    return;
                }

                _context.Vehicles.Remove(existingVehicle);
                _context.SaveChanges();
            }
        }
    }
}
