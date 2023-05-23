using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Handlers
{
    public static class VehicleTypeHandlers
    {
        // Create
        public static VehicleType CreateVehicleType(string typeName)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                VehicleType vehicleType = new VehicleType
                {
                    TypeName = typeName
                };
                _context.VehicleTypes.Add(vehicleType);
                _context.SaveChanges();

                return vehicleType;
            }
        }

        // Read (Single)
        public static VehicleType GetVehicleTypeById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                VehicleType vehicleType = _context.VehicleTypes.FirstOrDefault(v => v.VehicleTypeId == id);
                return vehicleType;
            }
        }

        // Read (All)
        public static List<VehicleType> GetAllVehicleTypes()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<VehicleType> vehicleTypes = _context.VehicleTypes.ToList();
                return vehicleTypes;
            }
        }

        // Update
        public static VehicleType UpdateVehicleType(VehicleType vehicleType)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                VehicleType existingVehicleType = _context.VehicleTypes.Find(vehicleType.VehicleTypeId);
                if(existingVehicleType == null)
                {
                    return existingVehicleType;
                }

                existingVehicleType.TypeName = vehicleType.TypeName;

                _context.SaveChanges();

                return existingVehicleType;
            }
        }

        // Delete
        public static void DeleteVehicleType(VehicleType vehicleType)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                VehicleType existingVehicleType = _context.VehicleTypes.Find(vehicleType.VehicleTypeId);
                if(existingVehicleType == null)
                {
                    return;
                }

                _context.VehicleTypes.Remove(existingVehicleType);
                _context.SaveChanges();
            }
        }
    }
}
