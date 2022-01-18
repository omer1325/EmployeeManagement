using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class EmployeeLeaveRequestRepository : Repository<EmployeeLeaveRequest>, IEmployeeLeaveRequestRepository
    {
        private readonly EmployeeManagementContext _context;

        public EmployeeLeaveRequestRepository(EmployeeManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
