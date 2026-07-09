using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class BillingRates
    {
        public int BillingRateId { get; private set; }
        public int MinimumConsumption { get; private set; }
        public int? MaximumConsumption { get; private set; }
        public decimal? PricePerCubicMeter { get; private set; }
        public decimal? MinimumCharge { get; private set; }
        public DateOnly EffectiveDate { get; private set; }
        public bool IsActive { get; private set; }

        protected BillingRates() { }

        public BillingRates(int minimumConsumption, int? maximumConsumption, decimal? pricePerCubicMeter, decimal? minimumCharge, DateOnly effectiveDate, bool isActive)
        {
            MinimumConsumption = minimumConsumption;
            MaximumConsumption = maximumConsumption;
            PricePerCubicMeter = pricePerCubicMeter;
            MinimumCharge = minimumCharge;
            EffectiveDate = effectiveDate;
            IsActive = isActive;
        }
    }
}
