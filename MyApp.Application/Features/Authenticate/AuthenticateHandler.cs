using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Application.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Authenticate
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, AuthenticationResponseDTO>
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticateHandler(IUserRepository userRepo, IPasswordHasher passwordHasher)
        {
            _userRepo = userRepo;
            _passwordHasher  = passwordHasher;
        }

        public async Task<AuthenticationResponseDTO> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepo.getUserByEmail(request.Email);
                if(user == null)
                {
                    return new AuthenticationResponseDTO
                    {
                        Success = false,
                        Message = "Email is invalid."
                    };
                }

                var verified = _passwordHasher.VerifyPasswordAsync(request.Password, user.PasswordHash);
                if(!verified)
                {
                    return new AuthenticationResponseDTO
                    {
                        Success = false,
                        Message = "Password invalid."
                    };
                }



            }
            catch (Exception ex)
            {
                return new AuthenticationResponseDTO
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
