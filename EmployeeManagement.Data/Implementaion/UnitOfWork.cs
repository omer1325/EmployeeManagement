using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;

namespace EmployeeManagement.Data.Implementaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagementContext _context;
        
        

        public UnitOfWork(EmployeeManagementContext context)
        {
            _context = context;
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
