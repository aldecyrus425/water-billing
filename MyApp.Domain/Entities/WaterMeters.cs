using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class WaterMeters
    {
        public int WaterMeterId { get; private set; }
        public int CustomerId { get; private set; }
        public Customers Customers { get; private set; }
        public string MeterSerialNumber { get; private set; }
        public string MeterBrand { get; private set; }
        public string MeterSize { get; private set; }
        public DateOnly InstallationDate {  get; private set; }
        public string MeterStatus { get; private set; } // Active, Damaged, Pulled Out, Replaced, etc.
        public decimal InitialReading { get; private set; }
        public decimal CurrentReading { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected WaterMeters() { }

        public WaterMeters(int customerId, string meterSerialNumber, string meterBrand, string meterSize, DateOnly installationDate, string meterStatus, decimal initialReading, decimal currentReading)
        {
            CustomerId = customerId;
            MeterSerialNumber = meterSerialNumber;
            MeterBrand = meterBrand;
            MeterSize = meterSize;
            InstallationDate = installationDate;
            MeterStatus = meterStatus;
            InitialReading = initialReading;
            CurrentReading = currentReading;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
