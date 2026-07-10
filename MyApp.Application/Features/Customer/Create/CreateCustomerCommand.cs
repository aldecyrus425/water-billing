using MediatR;
using MyApp.Application.Features.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.Create
{
    public class CreateCustomerCommand : IRequest<GenericResponse<string>>
    {
        public string Firstname { get; set; }
        public string? Middlename { get; set; }
        public string Lastname { get; set; }
        public string? BusinessName { get; set; }
        public string CustomerType { get; set; } 
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateOnly? ConnectionDate { get; set; }
        public string Status { get; set; }
    }
}
