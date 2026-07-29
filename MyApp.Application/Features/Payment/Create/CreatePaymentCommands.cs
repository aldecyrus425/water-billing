using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Features.Response;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Payment.Create
{
    public class CreatePaymentCommands : IRequest<GenericResponse<PaymentResponseDTO>>
    {
        public int BillId { get; set; }
        public string ORNumber { get;  set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountTendered { get; set; }
        public string PaymentMethod { get; set; } //Gcash, Bank Transfer, Cash, etc.
        public int ReceivedBy { get; set; }
        public string? Remarks { get; set; } 
    }
}
