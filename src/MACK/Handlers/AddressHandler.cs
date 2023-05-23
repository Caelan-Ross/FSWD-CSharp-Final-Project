using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Handlers
{
    public static class AddressHandlers
    {
        // Create
        public static Address CreateAddress(string street, string city, string province, string postalCode, string country, int corperationId,int? dealershpId = null)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Address address = new Address
                {
                    Street = street,
                    City = city,
                    Province = province,
                    PostalCode = postalCode,
                    Country = country,
                    DealershipId = dealershpId,
                    CorporationId = corperationId
                };
                _context.Addresses.Add(address);
                _context.SaveChanges();

                return address;
            }
        }

        // Read (Single)
        public static Address GetAddressById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Address address = _context.Addresses.FirstOrDefault(a => a.AddressId == id);
                return address;
            }
        }

        // Read (All)
        public static List<Address> GetAllAddresses()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Address> addresses = _context.Addresses.ToList();
                return addresses;
            }
        }

        // Update
        public static Address UpdateAddress(Address address)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Address existingAddress = _context.Addresses.Find(address.AddressId);
                if(existingAddress == null)
                {
                    return existingAddress;
                }

                existingAddress.Street = address.Street;
                existingAddress.City = address.City;
                existingAddress.Province = address.Province;
                existingAddress.PostalCode = address.PostalCode;
                existingAddress.Country = address.Country;
                existingAddress.DealershipId = address.DealershipId;
                existingAddress.CorporationId = address.CorporationId;
                _context.SaveChanges();

                return existingAddress;
            }
        }

        // Delete
        public static void DeleteAddress(Address address)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Address existingAddress = _context.Addresses.Find(address.AddressId);
                if(existingAddress == null)
                {
                    return;
                }


                _context.Addresses.Remove(existingAddress);
                _context.SaveChanges();
            }
        }
    }
}