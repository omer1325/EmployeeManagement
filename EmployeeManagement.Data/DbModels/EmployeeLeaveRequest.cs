using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data.DbModels
{
    public class EmployeeLeaveRequest : BaseEntity
    {
        //--------------------------------------------------//

        //Requesting user information
        public string RequestingEmployeeId { get; set; }
        [ForeignKey("RequestingEmployeeId")]
        public Employee RequestingEmployee { get; set; }

        //User information confirming the request
        public string ApprovedEmployeeId { get; set; }
        [ForeignKey("ApprovedEmployeeId")]
        public Employee ApprovedEmployee { get; set; }


        public int EmployeeLeaveTypeId { get; set; }
        [ForeignKey("EmployeeLeaveTypeId")]
        public EmployeeLeaveType EmployeeLeaveType { get; set; }

        //--------------------------------------------------//

        public DateTime StartDate { get; set; }
        public DateTime End { get; set; }
        public DateTime DateRequest { get; set; }
        public string RequestComments { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
