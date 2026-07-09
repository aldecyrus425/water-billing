using MediatR;
using MyApp.Application.Features.Response;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Role.GetAllRoles
{
    public class GetAllRoleHandler : IRequestHandler<GetAllRoleCommand, GenericResponse<IEnumerable<GetAllRoleDTO>>>
    {
        private readonly IRoleRepository _roleRepo;

        public GetAllRoleHandler(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<GenericResponse<IEnumerable<GetAllRoleDTO>>> Handle(GetAllRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _roleRepo.getRolesAsync();
                if(response == null)
                {
                    return new GenericResponse<IEnumerable<GetAllRoleDTO>>
                    {
                        isSuccess = true,
                        message = "No information for role yet."
                    };
                }

                var role = response.Select(x => new GetAllRoleDTO
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                });

                return new GenericResponse<IEnumerable<GetAllRoleDTO>>
                {
                    isSuccess = true,
                    message = "Role lists.",
                    Data = role
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<IEnumerable<GetAllRoleDTO>>
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
        }
    }
}
