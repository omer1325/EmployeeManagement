using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;

namespace EmployeeManagement.Data.Implementaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagementContext _context;
        public IEmployeeLeaveAllocationRepository employeeLeaveAllocationRepository { get; private set; }
        public IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; private set; }
        //public IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; private set; }
        public IEmployeeRepository employeeRepository { get; private set; }

        public UnitOfWork(EmployeeManagementContext context)
        {
            _context = context;
            employeeLeaveAllocationRepository = new EmployeeLeaveAllocationRepository(_context);
            employeeLeaveRequestRepository = new EmployeeLeaveRequestRepository(_context);
            //employeeLeaveTypeRepository = new EmployeeLeaveTypeRepository(_context);
            employeeRepository = new EmployeeRepository(_context);
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
