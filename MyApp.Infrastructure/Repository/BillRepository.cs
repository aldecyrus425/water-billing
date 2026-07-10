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
    public class BillRepository : IBillRepository
    {
        private readonly ApplicationDbContext _context;
        public BillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

            public async Task<Bills?> getPreviousBill(string serial)
            {
                return await _context.Bills
                    .Where(x => x.WaterMeterSerialNum == serial)
                    .OrderByDescending(x => x.BillingDate)
                    .FirstOrDefaultAsync();
            }
    }
}
