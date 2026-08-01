using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTOs
{
    public class AuthenticationDTO
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string? Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        
    }
}
