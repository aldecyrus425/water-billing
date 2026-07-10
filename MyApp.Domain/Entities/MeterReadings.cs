using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class MeterReadings
    {
        public int MeterReadingId { get; private set; }
        public string WaterMeterSerial { get; private set; }
        public WaterMeters WaterMeters { get; private set; }
        public string BillingMonth { get; private set; }
        public decimal PreviousReading { get; private set; }
        public decimal CurrentReading { get; private set; }
        public decimal Consumption { get; private set; }
        public DateTime ReadingDate { get; private set; }
        public int ReaderId { get; private set; }
        public Users Reader { get; private set; }
        public string? Remarks { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected MeterReadings() { }

        public MeterReadings(string waterMeterSerial, string billingMonth, decimal previousReading, decimal currentReading, decimal consumption, int readerId, string? remarks)
        {
            WaterMeterSerial = waterMeterSerial;
            BillingMonth = billingMonth;
            PreviousReading = previousReading;
            CurrentReading = currentReading;
            Consumption = consumption;
            ReadingDate = DateTime.UtcNow;
            ReaderId = readerId;
            Remarks = remarks;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
