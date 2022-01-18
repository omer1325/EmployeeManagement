using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{                                                                           
    public class EmployeeLeaveTypeRepository : Repository<EmployeeLeaveType>, IEmployeeLeaveTypeRepository
    {
        private readonly EmployeeManagementContext _context;

        public EmployeeLeaveTypeRepository(EmployeeManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
