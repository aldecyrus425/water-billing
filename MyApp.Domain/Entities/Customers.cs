using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Customers
    {
        public int CustomerId { get; private set; }
        public string CustomerNumber { get; private set; }
        public string Firstname { get; private set; }
        public string? Middlename { get; private set; }
        public string Lastname { get; private set; }
        public string? BusinessName { get; private set; }
        public string CustomerType { get; private set; } // Residential, Commercial, Industrial, Government
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public string Email { get; private set; }
        public DateOnly? ConnectionDate { get; private set; }
        public string Status { get; private set; } // Active, Inactive, Disconnected, Pending, Closed


        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public ICollection<WaterMeters> WaterMeters { get; private set; } = new List<WaterMeters>();
        public ICollection<Bills> Bills { get; private set; } = new List<Bills>();

        protected Customers() { }

        public Customers(string customerNumber, string firstname, string? middlename, string lastname, string? businessName, string customerType, string phone, string address, string email, DateOnly? connectionDate, string status)
        {
            CustomerNumber = customerNumber;
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            BusinessName = businessName;
            CustomerType = customerType;
            Phone = phone;
            Address = address;
            Email = email;
            ConnectionDate = connectionDate;
            Status = status;
            CreatedAt = DateTime.UtcNow;
        }

    }
}
