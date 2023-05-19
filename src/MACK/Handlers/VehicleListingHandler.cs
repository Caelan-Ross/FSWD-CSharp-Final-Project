using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Repository
{
    public static class VehicleListingRepository
    {
        // Create
        public static VehicleListing CreateVehicleListing(string vin, int stockNumber, int odometer, decimal msrp, decimal price,
            DateTime inventoryDate, bool certified, string description, string features, string photoUrlList, DateTime photosLastModifiedDate,
            int age, decimal cost, DateTime createdAt, DateTime updatedAt, DateTime deletedAt, int vehicleId, int dealershipId, int conditionId)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                VehicleListing vehicleListing = new VehicleListing
                {
                    VIN = vin,
                    StockNumber = stockNumber,
                    Odometer = odometer,
                    MSRP = msrp,
                    Price = price,
                    InventoryDate = inventoryDate,
                    Certified = certified,
                    Description = description,
                    Features = features,
                    PhotoUrlList = photoUrlList,
                    PhotosLastModifiedDate = photosLastModifiedDate,
                    Age = age,
                    Cost = cost,
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt,
                    DeletedAt = deletedAt,
                    VehicleId = vehicleId,
                    DealershipId = dealershipId,
                    ConditionId = conditionId
                };
                _context.VehicleListings.Add(vehicleListing);
                _context.SaveChanges();

                return vehicleListing;
            }
        }

        // Read (Single)
        public static VehicleListing GetVehicleListingById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                VehicleListing vehicleListing = _context.VehicleListings.FirstOrDefault(v => v.ListingId == id);
                return vehicleListing;
            }
        }

        // Read (All)
        public static List<VehicleListing> GetAllVehicleListings()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<VehicleListing> vehicleListings = _context.VehicleListings.ToList();
                return vehicleListings;
            }
        }

        // Update
        public static VehicleListing UpdateVehicleListing(VehicleListing vehicleListing)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                VehicleListing existingVehicleListing = _context.VehicleListings.Find(vehicleListing.ListingId);
                if(existingVehicleListing == null)
                {
                    return existingVehicleListing;
                }

                existingVehicleListing.VIN = vehicleListing.VIN;
                existingVehicleListing.StockNumber = vehicleListing.StockNumber;
                existingVehicleListing.Odometer = vehicleListing.Odometer;
                existingVehicleListing.MSRP = vehicleListing.MSRP;
                existingVehicleListing.Price = vehicleListing.Price;
                existingVehicleListing.InventoryDate = vehicleListing.InventoryDate;
                existingVehicleListing.Certified = vehicleListing.Certified;
                existingVehicleListing.Description = vehicleListing.Description;
                existingVehicleListing.Features = vehicleListing.Features;
                existingVehicleListing.PhotoUrlList = vehicleListing.PhotoUrlList;
                existingVehicleListing.PhotosLastModifiedDate = vehicleListing.PhotosLastModifiedDate;
                existingVehicleListing.Age = vehicleListing.Age;
                existingVehicleListing.Cost = vehicleListing.Cost;
                existingVehicleListing.CreatedAt = vehicleListing.CreatedAt;
                existingVehicleListing.UpdatedAt = vehicleListing.UpdatedAt;
                existingVehicleListing.DeletedAt = vehicleListing.DeletedAt;
                existingVehicleListing.VehicleId = vehicleListing.VehicleId;
                existingVehicleListing.DealershipId = vehicleListing.DealershipId;
                existingVehicleListing.ConditionId = vehicleListing.ConditionId;

                _context.SaveChanges();

                return existingVehicleListing;
            }
        }

        // Delete
        public static void DeleteVehicleListing(VehicleListing vehicleListing)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                VehicleListing existingVehicleListing = _context.VehicleListings.Find(vehicleListing.ListingId);
                if(existingVehicleListing == null)
                {
                    return;
                }

                _context.VehicleListings.Remove(existingVehicleListing);
                _context.SaveChanges();
            }
        }
    }
}
