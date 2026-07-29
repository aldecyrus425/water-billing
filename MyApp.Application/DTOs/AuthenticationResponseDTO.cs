using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTOs
{
    public class AuthenticationResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? UserId { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? ProfileURL { get; set; }
        public string? Token { get; set; }
        
    }
}
