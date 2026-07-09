using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class WaterMeterReplacements
    {
        public int WaterMeterReplacementId { get; private set; }
        public int OldMeterId { get; private set; }
        public int NewWaterMeterId { get; private set; }
        public WaterMeters NewWaterMeters { get; private set; }
        public DateTime ReplacementDate { get; private set; }
        public string Reason { get; private set; }
        public int PerformedBy { get; private set; }
        public Users User { get; private set; }

        public DateTime CreateAt { get; private set; }

        protected WaterMeterReplacements() { }

        public WaterMeterReplacements(int waterMeterReplacementId, int oldMeterId, int newWaterMeterId, WaterMeters newWaterMeters, DateTime replacementDate, string reason, int performedBy, Users user)
        {
            WaterMeterReplacementId = waterMeterReplacementId;
            OldMeterId = oldMeterId;
            NewWaterMeterId = newWaterMeterId;
            NewWaterMeters = newWaterMeters;
            ReplacementDate = replacementDate;
            Reason = reason;
            PerformedBy = performedBy;
            User = user;
            CreateAt = DateTime.Now;
        }
    }
}
