using System;

namespace EmployeeManagement.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
