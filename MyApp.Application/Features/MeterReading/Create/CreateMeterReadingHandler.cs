using MediatR;
using MyApp.Application.Features.Response;
using MyApp.Application.Interfaces.Repository;
using MyApp.Application.Interfaces.Service;
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
        private readonly INumberGenerator _numberGenerator;
        private readonly IBillingMonthRepository _billingMonthRepo;
        private readonly IPaymentRepository _paymentRepo;
        private readonly IBillingRateRepository _rateRepo;
        public CreateMeterReadingHandler(IMeterReadingRepository meterReadingRepository, IWaterMeterRepository waterMeterRepo, IBillRepository billRepo, INumberGenerator numberGenerator, IBillingMonthRepository billingMonthRepo, IPaymentRepository paymentRepo, IBillingRateRepository rateRepo)
        {
            _meterReadingRepository = meterReadingRepository;
            _waterMeterRepo = waterMeterRepo;
            _billRepo = billRepo;
            _numberGenerator = numberGenerator;
            _billingMonthRepo = billingMonthRepo;
            _paymentRepo = paymentRepo;
            _rateRepo = rateRepo;
        }

        public async Task<GenericResponse<CreateMeterReadingResponseDTO>> Handle(CreateMeterReadingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var billingMonth = await _billingMonthRepo.getBillingMonthById(request.BillingMonthId);
                if(billingMonth == null)
                {
                    return new GenericResponse<CreateMeterReadingResponseDTO>
                    {
                        isSuccess = false,
                        message = "Billing month invalid please try again."
                    };
                }

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

                var previousBalance = await getBalance(request.WaterMeterSerialNumber);

                decimal consumption = getConsumption(previousReading, request.CurrentReading);

                var waterReading = new MeterReadings(waterMeter.WaterMeterId, billingMonth.BillingMonthId, previousReading, request.CurrentReading, consumption, request.ReaderId, request.Remarks);
                await _meterReadingRepository.createReadingAsync(waterReading);

                var billingNumber = _numberGenerator.GenerateBillNumber();

                var currentCharges = await getCurrentCharges(consumption);

                var penaltyAmount = 0;
                var discountAmount = 0;
                var totalAmount = currentCharges + previousBalance;

                var billing = new Bills(billingNumber, waterMeter.CustomerId, waterReading.MeterReadingId, DateOnly.FromDateTime(DateTime.Now), billingMonth.DueDate, previousBalance, currentCharges, penaltyAmount, discountAmount, totalAmount, "Pending");
                await _billRepo.createBillAsync(billing);


                // Create Billing Items or break down

                var responseDTO = new CreateMeterReadingResponseDTO
                {
                    WaterMeterId = waterMeter.WaterMeterId,
                    BillingMonth = billingMonth.MonthName,
                    PreviousReading = previousReading,
                    CurrentReading = request.CurrentReading,
                    Consumption = consumption,
                    ReadingDate = DateTime.Now,
                    ReaderName = waterReading.Reader.Firstname + " " + waterReading.Reader.Lastname,
                    Remarks = request.Remarks,

                    BillNumber = billing.BillNumber,
                    ConsumerFirstName = waterMeter.Customers.Firstname,
                    ConsumerMiddleName = waterMeter.Customers.Middlename,
                    ConsumerLastName = waterMeter.Customers.Lastname,
                    BillingDate = billing.BillingDate,
                    DueDate = billingMonth.DueDate,
                    PreviousBalance = previousBalance,
                    CurrentCharges = currentCharges,
                    PenaltyAmount = penaltyAmount,
                    DiscountAmount = discountAmount,
                    TotalAmount = totalAmount,
                    BillStatus = billing.Status
                };

                return new GenericResponse<CreateMeterReadingResponseDTO>
                {
                    isSuccess = true,
                    message = "Meter reading successfully.",
                    Data = responseDTO
                };

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


        private async Task<decimal> getCurrentCharges(decimal consumption)
        {
            decimal total = 0;

            var rates = (await _rateRepo.getBillingRates())
                .OrderBy(r => r.MinimumConsumption);

            decimal remaining = consumption;

            foreach (var rate in rates)
            {
                if (remaining <= 0)
                    break;

                decimal blockSize;

                if (rate.MaximumConsumption == null)
                {
                    blockSize = remaining;
                }
                else
                {
                    blockSize = rate.MaximumConsumption.Value - rate.MinimumConsumption + 1;

                    if (remaining < blockSize)
                        blockSize = remaining;
                }

                total += blockSize * rate.PricePerCubicMeter!.Value;
                remaining -= blockSize;
            }

            return total;
        }

        private async Task<decimal> getBalance(string serial)
        {
            decimal previousBalance = 0;

            var previousBillingInformation = await _billRepo.getPreviousBill(serial);

            if (previousBillingInformation == null)
            {
                previousBalance = 0;
            }
            else
            {
                var recentPayment = await _paymentRepo.getPaymentByBillIdAsync(previousBillingInformation.BillId);

                if (recentPayment == null)
                {
                    previousBalance = previousBillingInformation.TotalAmount;
                }
                else
                {
                    previousBalance = previousBillingInformation.TotalAmount - recentPayment.AmountPaid;

                    if (previousBalance < 0) previousBalance = 0;
                }
            }

            return previousBalance;
        }
        private decimal getConsumption(decimal previousReading, decimal currentReading)
        {
            return currentReading - previousReading;
        }
    }
}
