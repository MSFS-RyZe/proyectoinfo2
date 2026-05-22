using System;

namespace Gestor
{
    public class Company
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Company(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}