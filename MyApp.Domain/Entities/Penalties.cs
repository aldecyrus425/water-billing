using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Penalties
    {
        public int PenaltyId { get; private set; }
        public int BillId { get; private set; }
        public Bills Bills { get; private set; }
        public DateTime PenaltyDate { get; private set; }
        public decimal Percentage { get; private set; }
        public decimal Amount { get; private set; }
        public string? Remarks { get; private set; }

        public DateTime CreatedAt { get; private set; }

        protected Penalties() { }

        public Penalties(int penaltyId, int billId, Bills bills, DateTime penaltyDate, decimal percentage, decimal amount, string? remarks)
        {
            PenaltyId = penaltyId;
            BillId = billId;
            Bills = bills;
            PenaltyDate = penaltyDate;
            Percentage = percentage;
            Amount = amount;
            Remarks = remarks;
            CreatedAt = DateTime.Now;
        }
    }
}
