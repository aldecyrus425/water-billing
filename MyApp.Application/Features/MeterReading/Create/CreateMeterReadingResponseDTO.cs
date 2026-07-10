using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.MeterReading.Create
{
    public class CreateMeterReadingResponseDTO
    {
        public int WaterMeterId { get; set; }
        public string BillingMonth { get; set; }
        public decimal PreviousReading { get; set; }
        public decimal CurrentReading { get; set; }
        public decimal Consumption { get; set; }
        public DateTime ReadingDate {  get; set; }
        public string ReaderName { get; set; }
        public string? Remarks { get; set; }

        public string BillNumber { get; set; }
        public string ConsumerFirstName { get; set; }
        public string? ConsumerMiddleName { get; set; }
        public string ConsumerLastName { get; set; }
        public DateOnly BillingDate {  get; set; }
        public DateOnly DueDate { get; set; }
        public decimal PreviousBalance { get; set; } = 0;
        public decimal CurrentCharges { get; set; } = 0;
        public decimal PenaltyAmount { get; set; } = 0;
        public decimal DiscountAmount { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public string BillStatus { get; set; }

    }
}
