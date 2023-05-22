using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Repository
{
    public static class ConditionRepository
    {
        // Create
        public static Condition CreateCondition(string conditionName, int vehicleListingId)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Condition condition = new Condition
                {
                    ConditionName = conditionName,
                    VehicleListingId = vehicleListingId
                };
                _context.Conditions.Add(condition);
                _context.SaveChanges();

                return condition;
            }
        }

        // Read (Single)
        public static Condition GetConditionById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Condition condition = _context.Conditions.FirstOrDefault(c => c.ConditionId == id);
                return condition;
            }
        }

        // Read (All)
        public static List<Condition> GetAllConditions()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Condition> conditions = _context.Conditions.ToList();
                return conditions;
            }
        }

        // Update
        public static Condition UpdateCondition(Condition condition)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Condition existingCondition = _context.Conditions.Find(condition.ConditionId);
                if(existingCondition == null)
                {
                    return existingCondition;
                }

                existingCondition.ConditionName = condition.ConditionName;
                existingCondition.VehicleListingId = condition.VehicleListingId;
                _context.SaveChanges();

                return existingCondition;
            }
        }

        // Delete
        public static void DeleteCondition(Condition condition)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Condition existingCondition = _context.Conditions.Find(condition.ConditionId);
                if(existingCondition == null)
                {
                    return;
                }

                _context.Conditions.Remove(existingCondition);
                _context.SaveChanges();
            }
        }
    }
}
