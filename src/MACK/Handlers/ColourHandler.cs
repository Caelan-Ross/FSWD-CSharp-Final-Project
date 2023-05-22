using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Repository
{
    public static class ColourRepository
    {
        // Create
        public static Colour CreateColour(string colourName, int vehicleId)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Colour colour = new Colour
                {
                    ColourName = colourName,
                    VehicleId = vehicleId
                };
                _context.Colours.Add(colour);
                _context.SaveChanges();

                return colour;
            }
        }

        // Read (Single)
        public static Colour GetColourById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Colour colour = _context.Colours.FirstOrDefault(c => c.ColourId == id);
                return colour;
            }
        }

        // Read (All)
        public static List<Colour> GetAllColours()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Colour> colours = _context.Colours.ToList();
                return colours;
            }
        }

        // Update
        public static Colour UpdateColour(Colour colour)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Colour existingColour = _context.Colours.Find(colour.ColourId);
                if(existingColour == null)
                {
                    return existingColour;
                }

                existingColour.ColourName = colour.ColourName;
                existingColour.VehicleId = colour.VehicleId;
                _context.SaveChanges();

                return existingColour;
            }
        }

        // Delete
        public static void DeleteColour(Colour colour)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Colour existingColour = _context.Colours.Find(colour.ColourId);
                if(existingColour == null)
                {
                    return;
                }

                _context.Colours.Remove(existingColour);
                _context.SaveChanges();
            }
        }
    }
}
