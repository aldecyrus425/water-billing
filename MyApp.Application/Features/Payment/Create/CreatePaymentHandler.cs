using FluentValidation;
using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Features.Response;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Payment.Create
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommands, GenericResponse<PaymentResponseDTO>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IPaymentRepository _paymentRepository;
        public CreatePaymentHandler(IBillRepository billRepository, IPaymentRepository paymentRepository)
        {
            _billRepository = billRepository;
            _paymentRepository = paymentRepository;
        }
        public async Task<GenericResponse<PaymentResponseDTO>> Handle(CreatePaymentCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var billExist = await _billRepository.getBillById(request.BillId);
                if (billExist == null)
                {
                    return new GenericResponse<PaymentResponseDTO>
                    {
                        isSuccess = false,
                        message = "Bill not exist."
                    };
                }

                // Here is look for the other record of the same bill id if there is made
                // a previous payment specially for initial payment.
                decimal advance = 0;
                var paymentHistory = await _paymentRepository.getPaymentByBillIdAsync(request.BillId);
                if (paymentHistory != null)
                {
                    advance += paymentHistory.AmountPaid;
                }

                var amountDue = billExist.TotalAmount - advance;

                decimal amountToApply = Math.Min(amountDue, request.AmountTendered);

                decimal change = request.AmountTendered - amountToApply;

                var payment = new Payments(request.BillId, request.ORNumber, request.PaymentDate, request.AmountPaid, request.AmountTendered, request.PaymentMethod, request.ReceivedBy, request.Remarks);
                await _paymentRepository.addPaymentAsync(payment);

                var response = new PaymentResponseDTO
                {
                    ChangeAmount = change
                };

                return new GenericResponse<PaymentResponseDTO>
                {
                    isSuccess = true,
                    message = "Payment added successfully.",
                    Data = new PaymentResponseDTO
                    {

                    }

                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<PaymentResponseDTO>
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
        }
    }
}
