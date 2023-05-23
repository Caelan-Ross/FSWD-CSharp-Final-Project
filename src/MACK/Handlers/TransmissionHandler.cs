using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Handlers
{
    public static class TransmissionHandlers
    {
        // Create
        public static Transmission CreateTransmission(string transmissionType, int transmissionGears)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Transmission transmission = new Transmission
                {
                    TransmissionType = transmissionType,
                    TransmissionGears = transmissionGears
                };
                _context.Transmissions.Add(transmission);
                _context.SaveChanges();

                return transmission;
            }
        }

        // Read (Single)
        public static Transmission GetTransmissionById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Transmission transmission = _context.Transmissions.FirstOrDefault(t => t.TransmissionId == id);
                return transmission;
            }
        }

        // Read (All)
        public static List<Transmission> GetAllTransmissions()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Transmission> transmissions = _context.Transmissions.ToList();
                return transmissions;
            }
        }

        // Update
        public static Transmission UpdateTransmission(Transmission transmission)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Transmission existingTransmission = _context.Transmissions.Find(transmission.TransmissionId);
                if(existingTransmission == null)
                {
                    return existingTransmission;
                }

                existingTransmission.TransmissionType = transmission.TransmissionType;
                existingTransmission.TransmissionGears = transmission.TransmissionGears;
                _context.SaveChanges();

                return existingTransmission;
            }
        }

        // Delete
        public static void DeleteTransmission(Transmission transmission)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Transmission existingTransmission = _context.Transmissions.Find(transmission.TransmissionId);
                if(existingTransmission == null)
                {
                    return;
                }

                _context.Transmissions.Remove(existingTransmission);
                _context.SaveChanges();
            }
        }
    }
}
