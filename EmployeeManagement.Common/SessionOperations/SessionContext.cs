﻿namespace EmployeeManagement.Common.SessionOperations
{
    public class SessionContext
    {
        public string LoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public bool IsAdmin { get; set; }
    }
}
