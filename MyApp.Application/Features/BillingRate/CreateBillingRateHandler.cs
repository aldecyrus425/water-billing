using MediatR;
using MyApp.Application.Features.Response;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.BillingRate
{
    public class CreateBillingRateHandler : IRequestHandler<CreateBillingRateCommand, GenericResponse<string>>
    {
        private readonly IBillingRateRepository _billingRateRepository;

        public CreateBillingRateHandler(IBillingRateRepository billingRateRepository)
        {
            _billingRateRepository = billingRateRepository;
        }

        public async Task<GenericResponse<string>> Handle(CreateBillingRateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var rate = new BillingRates(request.MinimumConsumption, request.MaximumConsumption, request.PricePerCubicMeter, request.MinimumCharge, request.EffectiveDate, request.IsActive);
                await _billingRateRepository.createBillingRateAsync(rate);

                return new GenericResponse<string>
                {
                    isSuccess = true,
                    message = "Billing rate created successfully."
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
        }
    }
}
