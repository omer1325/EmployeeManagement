using Microsoft.AspNetCore.Identity;
using System;

namespace EmployeeManagement.Data.DbModels
{
    public class Employee : IdentityUser
    {
        public string City { get; set; }
        public string Picture { get; set; }
        public DateTime? BirthDay { get; set; }
        public int Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TaxId { get; set; }
        
    }
}
