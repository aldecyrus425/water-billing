using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class WaterMeterRepository : IWaterMeterRepository
    {
        private readonly ApplicationDbContext _context;
        public WaterMeterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task createWaterMeterAsync(WaterMeters waterMeter)
        {
            await _context.WaterMeters.AddAsync(waterMeter);
            await _context.SaveChangesAsync();
        }
    }
}
