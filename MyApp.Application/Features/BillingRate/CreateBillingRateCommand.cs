using MediatR;
using MyApp.Application.Features.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.BillingRate
{
    public class CreateBillingRateCommand : IRequest<GenericResponse<string>>
    {
        public int MinimumConsumption { get; set; }
        public int? MaximumConsumption { get; set; }
        public decimal? PricePerCubicMeter { get; set; }
        public decimal? MinimumCharge { get; set; }
        public DateOnly EffectiveDate { get; set; }
        public bool IsActive { get; set; }
    }
}
