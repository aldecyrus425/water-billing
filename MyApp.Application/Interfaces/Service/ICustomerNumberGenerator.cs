using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Service
{
    public interface INumberGenerator
    {
        string GenerateCustomerNumber();
        string GenerateBillNumber();
    }
}
