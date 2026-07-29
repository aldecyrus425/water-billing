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
    public class BillingMonthRepository : IBillingMonthRepository
    {
        private readonly ApplicationDbContext _context;
        public BillingMonthRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<BillingMonths?> getBillingMonthById(int Id)
        {
            return await _context.BillingMonths.FirstOrDefaultAsync(x => x.BillingMonthId == Id);
        }
    }
}
