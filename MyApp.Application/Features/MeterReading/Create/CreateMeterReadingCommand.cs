using MediatR;
using MyApp.Application.Features.Response;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.MeterReading.Create
{
    public class CreateMeterReadingCommand : IRequest<GenericResponse<CreateMeterReadingResponseDTO>>
    {
        public string WaterMeterSerialNumber { get; set; }
        public string BillingMonth { get; set; }
        public decimal CurrentReading { get; set; }
        public DateTime ReadingDate { get; set; }
        public int ReaderId { get; set; }
        public string? Remarks { get; set; }
    }
}
