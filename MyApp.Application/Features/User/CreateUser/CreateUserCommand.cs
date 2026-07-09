using MediatR;
using MyApp.Application.Features.Response;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.User.CreateUser
{
    public class CreateUserCommand : IRequest<GenericResponse<string>>
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Firstname { get; set; }
        public string? Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
