using MediatR;
using MyApp.Application.Features.Response;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.WaterMeter.Create
{
    public class CreateWaterMeterHandler : IRequestHandler<CreateWaterMeterCommand, GenericResponse<string>>
    {
        private readonly IWaterMeterRepository _waterMeterRepo;
        public CreateWaterMeterHandler(IWaterMeterRepository waterMeterRepo)
        {
            _waterMeterRepo = waterMeterRepo;
        }

        public async Task<GenericResponse<string>> Handle(CreateWaterMeterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var waterMeter = new WaterMeters(request.CustomerId, request.MeterSerialNumber, request.MeterBrand, request.MeterSize, request.InstallationDate, request.MeterStatus, request.InitialReading, request.CurrentReading);
                await _waterMeterRepo.createWaterMeterAsync(waterMeter);

                return new GenericResponse<string>
                {
                    isSuccess = true,
                    message = "Water meter created successfully."
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
