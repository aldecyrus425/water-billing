using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Roles
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<Users> Users { get; private set; } = new List<Users>();

        protected Roles() { }

        public Roles(string name)
        {
            Name = name;
        }
    }
}
