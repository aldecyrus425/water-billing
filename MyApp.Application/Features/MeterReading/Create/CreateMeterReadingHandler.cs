using MediatR;
using MyApp.Application.Features.Response;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.MeterReading.Create
{
    public class CreateMeterReadingHandler : IRequestHandler<CreateMeterReadingCommand, GenericResponse<CreateMeterReadingResponseDTO>>
    {
        private readonly IMeterReadingRepository _meterReadingRepository;
        private readonly IWaterMeterRepository _waterMeterRepo;
        private readonly IBillRepository _billRepo;
        public CreateMeterReadingHandler(IMeterReadingRepository meterReadingRepository, IWaterMeterRepository waterMeterRepo, IBillRepository billRepo)
        {
            _meterReadingRepository = meterReadingRepository;
            _waterMeterRepo = waterMeterRepo;
            _billRepo = billRepo;
        }

        public async Task<GenericResponse<CreateMeterReadingResponseDTO>> Handle(CreateMeterReadingCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var waterMeter = await _waterMeterRepo.getWaterMeterBySerialAsync(request.WaterMeterSerialNumber);
                if(waterMeter == null)
                {
                    return new GenericResponse<CreateMeterReadingResponseDTO>
                    {
                        isSuccess = false,
                        message = $"Water meter not found with this serial: {request.WaterMeterSerialNumber}"
                    };
                }

                var previousWaterReadingInformation = await _meterReadingRepository.getPreviousReading(request.WaterMeterSerialNumber);
                var previousReading = previousWaterReadingInformation?.CurrentReading ?? waterMeter.InitialReading;

                if(request.CurrentReading < previousReading)
                {
                    return new GenericResponse<CreateMeterReadingResponseDTO>
                    {
                        isSuccess = false,
                        message = "current reading must be greater than previous reading."
                        
                    };
                }

                var previousBillingInformation = await _billRepo.getPreviousBill(request.WaterMeterSerialNumber);
                var consumption = getConsumption(previousReading, request.CurrentReading);

                var waterReading = new MeterReadings(request.WaterMeterSerialNumber, request.BillingMonth, previousReading, request.CurrentReading, consumption, request.ReaderId, request.Remarks);
                await _meterReadingRepository.createReadingAsync(waterReading);



            }
            catch (Exception ex)
            {
                return new GenericResponse<CreateMeterReadingResponseDTO>
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }

        }

        private decimal getConsumption(decimal previousReading, decimal currentReading)
        {
            return currentReading - previousReading;
        }
    }
}
