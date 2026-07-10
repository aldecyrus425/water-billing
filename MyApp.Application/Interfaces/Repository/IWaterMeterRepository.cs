using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IWaterMeterRepository
    {
        Task<WaterMeters?> getWaterMeterBySerialAsync(string serialNum);
        Task createWaterMeterAsync(WaterMeters waterMeter);
    }
}
