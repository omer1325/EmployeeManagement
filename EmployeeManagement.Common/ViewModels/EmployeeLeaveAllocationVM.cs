using System;

namespace EmployeeManagement.Common.ViewModels
{
    public class EmployeeLeaveAllocationVM : BaseEntityVM
    {
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        public string EmployeeId { get; set; }
        public EmployeeVM Employee { get; set; }



        public int EmployeeLeaveTypeId { get; set; }
        public EmployeeLeaveTypeVM EmployeeLeaveTypeVm { get; set; }
    }
}
