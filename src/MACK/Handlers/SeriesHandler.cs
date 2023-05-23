using MACK.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MACK.Handlers
{
    public static class SeriesHandlers
    {
        // Create
        public static Series CreateSeries(string seriesName, int modelId)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Series series = new Series
                {
                    SeriesName = seriesName,
                    ModelId = modelId
                };
                _context.Series.Add(series);
                _context.SaveChanges();

                return series;
            }
        }

        // Read (Single)
        public static Series GetSeriesById(int id)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Series series = _context.Series.FirstOrDefault(s => s.SeriesId == id);
                return series;
            }
        }

        // Read (All)
        public static List<Series> GetAllSeries()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Series> series = _context.Series.ToList();
                return series;
            }
        }

        // Update
        public static Series UpdateSeries(Series series)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Series existingSeries = _context.Series.Find(series.SeriesId);
                if(existingSeries == null)
                {
                    return existingSeries;
                }

                existingSeries.SeriesName = series.SeriesName;
                existingSeries.ModelId = series.ModelId;
                _context.SaveChanges();

                return existingSeries;
            }
        }

        // Delete
        public static void DeleteSeries(Series series)
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                Series existingSeries = _context.Series.Find(series.SeriesId);
                if(existingSeries == null)
                {
                    return;
                }

                _context.Series.Remove(existingSeries);
                _context.SaveChanges();
            }
        }
    }
}
