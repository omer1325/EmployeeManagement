using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Common.ViewModels
{
    public class EmployeeLeaveRequestVM : BaseEntityVM
    {
        public string RequestingEmployeeId { get; set; }
        public EmployeeVM RequestingEmployee { get; set; }

        //User information confirming the request
        public string ApprovedEmployeeId { get; set; }
        public EmployeeVM ApprovedEmployee { get; set; }


        public int EmployeeLeaveTypeId { get; set; }
        public EmployeeLeaveTypeVM EmployeeLeaveType { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime End { get; set; }
        public DateTime DateRequest { get; set; }
        [Display(Name = "Talep Açıklama")]
        [MaxLength(300, ErrorMessage = "300 karakterden fazla değer girilemez")]
        public string RequestComments { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
