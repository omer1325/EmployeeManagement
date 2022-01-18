using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class EmployeeLeaveAllocationRepository : Repository<EmployeeLeaveAllocation>, IEmployeeLeaveAllocationRepository
    {
        private readonly EmployeeManagementContext _context;

        public EmployeeLeaveAllocationRepository(EmployeeManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
