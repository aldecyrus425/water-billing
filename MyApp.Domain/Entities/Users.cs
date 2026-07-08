using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Users
    {
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string Firstname { get; private set; }
        public string? Middlename { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public int RoleId { get; private set; }
        public Roles Role { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime? UpdateAt { get; private set; }

        protected Users() { }

        public Users(string username, string passwordHash, string firstName, string? middleName, string lastName, string email, string phone, int roleId, bool isActive)
        {
            Username = username;
            PasswordHash = passwordHash;
            Firstname = firstName;
            Middlename = middleName;
            Lastname = lastName;
            Email = email;
            Phone = phone;
            RoleId = roleId;
            IsActive = isActive;
            CreateAt = DateTime.UtcNow;
        }
    }
}
