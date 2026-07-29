using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Authenticate
{
    public class AuthenticateCommand : IRequest<AuthenticationResponseDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
