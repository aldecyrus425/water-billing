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

namespace MyApp.Application.Features.User.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, GenericResponse<string>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserHandler(IUserRepository userRepo, IPasswordHasher passwordHasher)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
        }


        public async Task<GenericResponse<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var hashPassword = _passwordHasher.HashPasswordAsync(request.PasswordHash);

                var user = new Users(request.Username, hashPassword, request.Firstname, request.Middlename, request.Lastname, request.Email, request.Phone, request.RoleId, request.IsActive);

                await _userRepo.CreateUserAsync(user);

                return new GenericResponse<string>
                {
                    isSuccess = true,
                    message = "User created successfully."
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
