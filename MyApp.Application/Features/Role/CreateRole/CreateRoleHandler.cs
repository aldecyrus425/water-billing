using MediatR;
using MyApp.Application.Features.Response;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Role.CreateRole
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, GenericResponse<string>>
    {
        private readonly IRoleRepository _roleRepo;

        public CreateRoleHandler(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }


        public async Task<GenericResponse<string>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = new Roles(request.Name);
                await _roleRepo.createRoleAsync(role);

                return new GenericResponse<string>
                {
                    isSuccess = true,
                    message = "Role created succesfully.",
                    Data = role.Name
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
