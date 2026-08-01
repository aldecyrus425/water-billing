using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Features.Response;
using MyApp.Application.Interfaces.Repository;
using MyApp.Application.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Authenticate
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, GenericResponse<AuthenticationDTO>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthServices _authService;

        public AuthenticateHandler(IUserRepository userRepo, IPasswordHasher passwordHasher, IAuthServices authServices)
        {
            _userRepo = userRepo;
            _passwordHasher  = passwordHasher;
            _authService = authServices;
        }

        public async Task<GenericResponse<AuthenticationDTO>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepo.getUserByEmail(request.Email);
                if(user == null)
                {
                    return new GenericResponse<AuthenticationDTO>
                    {
                        isSuccess = false,
                        message = "Email is invalid."
                    };
                }

                var verified = _passwordHasher.VerifyPasswordAsync(request.Password, user.PasswordHash);
                if(!verified)
                {
                    return new GenericResponse<AuthenticationDTO>
                    {
                        isSuccess = false,
                        message = "Password invalid."
                    };
                }


                var token = await _authService.GenerateToken(user);

                return new GenericResponse<AuthenticationDTO>
                {
                    isSuccess = true,
                    message = "Successfully authenticated.",
                    Data = new AuthenticationDTO
                    {
                        UserId = user.UserId,
                        Firstname = user.Firstname,
                        Middlename = user.Middlename,
                        Lastname = user.Lastname,
                        Email = user.Email,
                        Role = user.Role.Name,
                        Token = token
                    }
                };


            }
            catch (Exception ex)
            {
                return new GenericResponse<AuthenticationDTO>
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
        }
    }
}
