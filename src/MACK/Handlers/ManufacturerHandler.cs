using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Repository
{
    public static class ManufacturerRepository
    {
        // Create
        public static Manufacturer CreateManufacturer(string manufacturerName)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerName = manufacturerName
                };
                _context.Manufacturers.Add(manufacturer);
                _context.SaveChanges();

                return manufacturer;
            }
        }

        // Read (Single)
        public static Manufacturer GetManufacturerById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Manufacturer manufacturer = _context.Manufacturers.FirstOrDefault(m => m.ManufacturerId == id);
                return manufacturer;
            }
        }

        // Read (All)
        public static List<Manufacturer> GetAllManufacturers()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Manufacturer> manufacturers = _context.Manufacturers.ToList();
                return manufacturers;
            }
        }

        // Update
        public static Manufacturer UpdateManufacturer(Manufacturer manufacturer)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Manufacturer existingManufacturer = _context.Manufacturers.Find(manufacturer.ManufacturerId);
                if(existingManufacturer == null)
                {
                    return existingManufacturer;
                }

                existingManufacturer.ManufacturerName = manufacturer.ManufacturerName;
                _context.SaveChanges();

                return existingManufacturer;
            }
        }

        // Delete
        public static void DeleteManufacturer(Manufacturer manufacturer)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Manufacturer existingManufacturer = _context.Manufacturers.Find(manufacturer.ManufacturerId);
                if(existingManufacturer == null)
                {
                    return;
                }

                _context.Manufacturers.Remove(existingManufacturer);
                _context.SaveChanges();
            }
        }
    }
}
