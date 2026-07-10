using Microsoft.EntityFrameworkCore;
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
    public class MeterReadingRepository : IMeterReadingRepository
    {
        private readonly ApplicationDbContext _context;

        public MeterReadingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task createReadingAsync(MeterReadings reading)
        {
            await _context.MeterReadings.AddAsync(reading);
            await _context.SaveChangesAsync();
        }

        public async Task<MeterReadings?> getPreviousReading(string serial)
        {
            return await _context.MeterReadings
                .Where(x => x.WaterMeterSerial == serial)
                .OrderByDescending(x => x.ReadingDate)
                .FirstOrDefaultAsync();
        }
    }
}
