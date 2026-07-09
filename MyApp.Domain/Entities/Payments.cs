using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Payments
    {
        public int PaymentId { get; private set; }
        public int BillId { get; private set; }
        public Bills Bills { get; private set; }
        public string ORNumber { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public decimal AmountPaid { get; private set; }
        public string PaymentMethod { get; private set; } //Gcash, Bank Transfer, Cash, etc.
        public int ReceivedBy { get; private set; }
        public Users UserReceived { get; private set; }
        public string? Remarks { get; private set; }

        public DateTime CreatedAt { get; private set; }

        protected Payments() { }

        public Payments(int billId, string orNumber, DateTime paymentDate, decimal amountPaid, string paymentMethod, int receivedBy, string? remarks)
        {
            BillId = billId;
            ORNumber = orNumber;
            PaymentDate = paymentDate;
            AmountPaid = amountPaid;
            PaymentMethod = paymentMethod;
            ReceivedBy = receivedBy;
            Remarks = remarks;
            CreatedAt = DateTime.Now;
        }
    }
}
