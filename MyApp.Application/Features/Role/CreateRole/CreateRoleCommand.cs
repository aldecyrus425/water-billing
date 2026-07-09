using MediatR;
using MyApp.Application.Features.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Role.CreateRole
{
    public class CreateRoleCommand : IRequest<GenericResponse<string>>
    {
        public string Name { get; set; }
    }
}
