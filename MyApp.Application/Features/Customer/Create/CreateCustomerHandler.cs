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

namespace MyApp.Application.Features.Customer.Create
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, GenericResponse<string>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerNumberGenerator _numberGenerator;

        public CreateCustomerHandler(ICustomerRepository customerRepository, ICustomerNumberGenerator numberGenerator)
        {
            _customerRepository = customerRepository;
            _numberGenerator = numberGenerator;
        }


        public async Task<GenericResponse<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var CustomerNumber = _numberGenerator.GenerateCustomerNumber();

                var customer = new Customers(CustomerNumber, request.Firstname, request.Middlename, request.Lastname, request.BusinessName, request.CustomerType, request.Phone, request.Address, request.Email, request.ConnectionDate, request.Status);
                await _customerRepository.createCustomerAsync(customer);

                return new GenericResponse<string>
                {
                    isSuccess = true,
                    message = "Customer created successfully.",
                    Data = customer.CustomerNumber
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
