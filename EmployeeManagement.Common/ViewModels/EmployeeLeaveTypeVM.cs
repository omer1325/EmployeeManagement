using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Common.ViewModels
{
    public class EmployeeLeaveTypeVM : BaseEntityVM
    {
        [Required]
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }

        //MVVM Create EmployeeType
        public void SetEmployeeType(string name)
        {
            this.Name = name;
        }
    }
}
