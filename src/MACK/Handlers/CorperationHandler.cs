using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Repository
{
    public static class CorporationRepository
    {
        // Create
        public static Corporation CreateCorporation(string corporationName, int addressId)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Corporation corporation = new Corporation
                {
                    CorporationName = corporationName,
                    AddressId = addressId
                };
                _context.Corporations.Add(corporation);
                _context.SaveChanges();

                return corporation;
            }
        }

        // Read (Single)
        public static Corporation GetCorporationById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Corporation corporation = _context.Corporations.FirstOrDefault(c => c.CorporationId == id);
                return corporation;
            }
        }

        // Read (All)
        public static List<Corporation> GetAllCorporations()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Corporation> corporations = _context.Corporations.ToList();
                return corporations;
            }
        }

        // Update
        public static Corporation UpdateCorporation(Corporation corporation)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Corporation existingCorporation = _context.Corporations.Find(corporation.CorporationId);
                if(existingCorporation == null)
                {
                    return existingCorporation;
                }

                existingCorporation.CorporationName = corporation.CorporationName;
                existingCorporation.AddressId = corporation.AddressId;
                _context.SaveChanges();

                return existingCorporation;
            }
        }

        // Delete
        public static void DeleteCorporation(Corporation corporation)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Corporation existingCorporation = _context.Corporations.Find(corporation.CorporationId);
                if(existingCorporation == null)
                {
                    return;
                }

                _context.Corporations.Remove(existingCorporation);
                _context.SaveChanges();
            }
        }
    }
}
