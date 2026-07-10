using MediatR;
using MyApp.Application.Features.Response;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.WaterMeter.Create
{
    public class CreateWaterMeterCommand : IRequest<GenericResponse<string>>
    {
        public int CustomerId { get; set; }
        public string MeterSerialNumber { get; set; }
        public string MeterBrand { get; set; }
        public string MeterSize { get; set; }
        public DateOnly InstallationDate { get; set; }
        public string MeterStatus { get; set; }
        public decimal InitialReading { get; set; }
        public decimal CurrentReading { get; set; }

    }
}
