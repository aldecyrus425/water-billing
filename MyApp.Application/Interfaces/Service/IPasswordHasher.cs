using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Service
{
    public interface IPasswordHasher
    {
        string HashPasswordAsync(string password);
        bool VerifyPasswordAsync(string password, string hashPassword);
    }
}
