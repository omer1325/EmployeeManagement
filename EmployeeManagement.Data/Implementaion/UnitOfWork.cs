using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;

namespace EmployeeManagement.Data.Implementaion
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagementContext _context;
        public IEmployeeLeaveAllocationRepository employeeLeaveAllocationRepository { get; private set; }
        public IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; private set; }
        public IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; private set; }

        public UnitOfWork(EmployeeManagementContext context)
        {
            _context = context;
            employeeLeaveAllocationRepository = new EmployeeLeaveAllocationRepository(context);
            employeeLeaveRequestRepository = new EmployeeLeaveRequestRepository(context);
            employeeLeaveTypeRepository = new EmployeeLeaveTypeRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
