using MyApp.Application.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class CustomerNumberGenerator : ICustomerNumberGenerator
    {
        public string GenerateCustomerNumber()
        {
            return $"{GenerateDigits(4)}-{GenerateDigits(3)}-{GenerateDigits(3)}-{GenerateDigits(4)}";
        }

        private static string GenerateDigits(int length)
        {
            var sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(RandomNumberGenerator.GetInt32(0, 10));
            }

            return sb.ToString();
        }
    }
}
