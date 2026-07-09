using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Roles>> getRolesAsync();

        Task createRoleAsync(Roles role);
    }
}
