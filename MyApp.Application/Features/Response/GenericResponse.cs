using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Response
{
    public class GenericResponse<T>
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public T? Data { get; set; }
    }
}
