using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Bills
    {
        public int BillId { get; private set; }
        public string BillNumber { get; private set; }

        public string WaterMeterSerialNum { get; private set; }

        public int CustomerId { get; private set; }
        public Customers Customer { get; private set; }

        public int MeterReadingId { get; private set; }
        public MeterReadings MeterReading { get; private set; }

        public DateOnly BillingDate { get; private set; }
        public DateOnly DueDate { get; private set; }
        public decimal PreviousBalance { get; private set; } = 0;
        public decimal CurrentCharges { get; private set; }
        public decimal PenaltyAmount { get; private set; } = 0;
        public decimal DiscountAmount { get; private set; } = 0;
        public decimal TotalAmount { get; private set; }
        public string Status { get; private set; } // Pending, Partially Paid, Paid, Overdue, Cancelled

        public DateTime CreatedAt { get; private set; }

        public ICollection<BillItems> BillItems { get; private set; } = new List<BillItems>();
        public ICollection<Payments> Payments { get; private set; } = new List<Payments>();
        public ICollection<Penalties> Penalties { get; private set; } = new List<Penalties>();

        protected Bills() { }

        public Bills(int billId, string billNumber, int customerId, Customers customer, int meterReadingId, MeterReadings meterReading, DateOnly billingDate, DateOnly dueDate, decimal previousBalance, decimal currentCharges, decimal penaltyAmount, decimal discountAmount, decimal totalAmount, string status, DateTime createdAt)
        {
            BillId = billId;
            BillNumber = billNumber;
            CustomerId = customerId;
            Customer = customer;
            MeterReadingId = meterReadingId;
            MeterReading = meterReading;
            BillingDate = billingDate;
            DueDate = dueDate;
            PreviousBalance = previousBalance;
            CurrentCharges = currentCharges;
            PenaltyAmount = penaltyAmount;
            DiscountAmount = discountAmount;
            TotalAmount = totalAmount;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}
