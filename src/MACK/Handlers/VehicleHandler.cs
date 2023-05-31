using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Handlers
{
    public static class VehicleHandlers
    {
        // Create
        public static Vehicle CreateVehicle(string vin, int year,string fuel, string exteriorColour, string interiorColour, int bodyDoorCount, 
            bool isUsed, bool isAutomatic, string features, string description, int modelId, double price, string stockNumber)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Vehicle vehicle = new Vehicle
                {
                    VIN = vin,
                    Year = year,
                    Fuel = fuel,
                    ExteriorColour = exteriorColour,
                    InteriorColour = interiorColour,
                    BodyDoorCount = bodyDoorCount,
                    Features = features,
                    Description = description,
                    IsAutomatic = isAutomatic,
                    IsUsed = isUsed,
                    ModelId = modelId,
                    Price = price,
                    StockNumber = stockNumber
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
                existingVehicle.Fuel = vehicle.Fuel;
                existingVehicle.BodyDoorCount = vehicle.BodyDoorCount;
                existingVehicle.ExteriorColour = vehicle.ExteriorColour;
                existingVehicle.InteriorColour = vehicle.InteriorColour;
                existingVehicle.IsUsed = vehicle.IsUsed;
                existingVehicle.IsAutomatic = vehicle.IsAutomatic;
                existingVehicle.Features = vehicle.Features;
                existingVehicle.Description = vehicle.Description;
                existingVehicle.ModelId = vehicle.ModelId;
                existingVehicle.Price = vehicle.Price;
                existingVehicle.StockNumber = vehicle.StockNumber;

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

        public static bool IfVehicleExists(string vin, int modelId)
        {
            bool exists = false;

            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                try
                {
                    Vehicle vehicle = _context.Vehicles.First(m => m.VIN == vin && m.ModelId == modelId);
                    exists = true;
                }catch { }
            }

            return exists;
        }
    }
}
