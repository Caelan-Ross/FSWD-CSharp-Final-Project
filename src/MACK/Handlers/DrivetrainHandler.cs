using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Handlers
{
    public static class DrivetrainHandlers
    {
        // Create
        public static Drivetrain CreateDrivetrain(string drivetrainType, int vehicleId)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Drivetrain drivetrain = new Drivetrain
                {
                    DrivetrainType = drivetrainType,
                    VehicleId = vehicleId
                };
                _context.Drivetrains.Add(drivetrain);
                _context.SaveChanges();

                return drivetrain;
            }
        }

        // Read (Single)
        public static Drivetrain GetDrivetrainById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Drivetrain drivetrain = _context.Drivetrains.FirstOrDefault(d => d.DrivetrainId == id);
                return drivetrain;
            }
        }

        // Read (All)
        public static List<Drivetrain> GetAllDrivetrains()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Drivetrain> drivetrains = _context.Drivetrains.ToList();
                return drivetrains;
            }
        }

        // Update
        public static Drivetrain UpdateDrivetrain(Drivetrain drivetrain)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Drivetrain existingDrivetrain = _context.Drivetrains.Find(drivetrain.DrivetrainId);
                if(existingDrivetrain == null)
                {
                    return existingDrivetrain;
                }

                existingDrivetrain.DrivetrainType = drivetrain.DrivetrainType;
                existingDrivetrain.VehicleId = drivetrain.VehicleId;
                _context.SaveChanges();

                return existingDrivetrain;
            }
        }

        // Delete
        public static void DeleteDrivetrain(Drivetrain drivetrain)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Drivetrain existingDrivetrain = _context.Drivetrains.Find(drivetrain.DrivetrainId);
                if(existingDrivetrain == null)
                {
                    return;
                }

                _context.Drivetrains.Remove(existingDrivetrain);
                _context.SaveChanges();
            }
        }
    }
}
