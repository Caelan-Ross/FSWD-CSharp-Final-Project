using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Handlers
{
    public static class ModelHandlers
    {
        // Create
        public static Model CreateModel(string modelName, int manufacturerId)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Model model = new Model
                {
                    ModelName = modelName,
                    ManufacturerId = manufacturerId
                };
                _context.Models.Add(model);
                _context.SaveChanges();

                return model;
            }
        }

        // Read (Single)
        public static Model GetModelById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Model model = _context.Models.FirstOrDefault(m => m.ModelId == id);
                return model;
            }
        }

        // Read (All)
        public static List<Model> GetAllModels()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Model> models = _context.Models.ToList();
                return models;
            }
        }

        // Update
        public static Model UpdateModel(Model model)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Model existingModel = _context.Models.Find(model.ModelId);
                if(existingModel == null)
                {
                    return existingModel;
                }

                existingModel.ModelName = model.ModelName;
                existingModel.ManufacturerId = model.ManufacturerId;
                _context.SaveChanges();

                return existingModel;
            }
        }

        // Delete
        public static void DeleteModel(Model model)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Model existingModel = _context.Models.Find(model.ModelId);
                if(existingModel == null)
                {
                    return;
                }

                _context.Models.Remove(existingModel);
                _context.SaveChanges();
            }
        }

        public static Model IfModelExists(string name, int manufacturerId)
        {
            Model model = new Model();

            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                try
                {
                    model = _context.Models.First(m => m.ModelName.ToLower() == name.ToLower() && m.ManufacturerId == manufacturerId);
                }
                catch
                {
                    model = CreateModel(name, manufacturerId);

                }
            }

            return (model);
        }
    }
}
