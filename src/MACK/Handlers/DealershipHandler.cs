using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Handlers
{
    public static class DealershipHandlers
    {
        // Create
        public static Dealership CreateDealership(string dealershipName, int corporationId, int addressId)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Dealership dealership = new Dealership
                {
                    DealershipName = dealershipName,
                    CorporationId = corporationId,
                    AddressId = addressId
                };
                _context.Dealerships.Add(dealership);
                _context.SaveChanges();

                return dealership;
            }
        }

        // Read (Single)
        public static Dealership GetDealershipById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Dealership dealership = _context.Dealerships.FirstOrDefault(d => d.DealershipId == id);
                return dealership;
            }
        }

        // Read (All)
        public static List<Dealership> GetAllDealerships()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Dealership> dealerships = _context.Dealerships.ToList();
                return dealerships;
            }
        }

        // Update
        public static Dealership UpdateDealership(Dealership dealership)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Dealership existingDealership = _context.Dealerships.Find(dealership.DealershipId);
                if(existingDealership == null)
                {
                    return existingDealership;
                }

                existingDealership.DealershipName = dealership.DealershipName;
                existingDealership.CorporationId = dealership.CorporationId;
                existingDealership.AddressId = dealership.AddressId;
                _context.SaveChanges();

                return existingDealership;
            }
        }

        // Delete
        public static void DeleteDealership(Dealership dealership)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Dealership existingDealership = _context.Dealerships.Find(dealership.DealershipId);
                if(existingDealership == null)
                {
                    return;
                }

                _context.Dealerships.Remove(existingDealership);
                _context.SaveChanges();
            }
        }
    }
}
