using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IMeterReadingRepository
    {
        Task createReadingAsync(MeterReadings reading);

        Task<MeterReadings?> getPreviousReading(string serial);
    }
}
