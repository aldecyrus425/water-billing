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
    public class BillingRateRepository : IBillingRateRepository
    {
        private readonly ApplicationDbContext _context;

        public BillingRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task createBillingRateAsync(BillingRates rate)
        {
            await _context.BillingRates.AddAsync(rate);
            await _context.SaveChangesAsync();

        }
    }
}
