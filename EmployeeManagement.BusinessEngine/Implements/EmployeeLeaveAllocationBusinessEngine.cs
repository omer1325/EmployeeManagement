using AutoMapper;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.BusinessEngine.ResultModels;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DbModels;
using System;

namespace EmployeeManagement.BusinessEngine.Implements
{
    public class EmployeeLeaveAllocationBusinessEngine : IEmployeeLeaveAllocationBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmployeeLeaveRequestRepository _employeeLeaveRequestRepository;
        private readonly IEmployeeLeaveAllocationRepository _employeeLeaveAllocationRepository;
        #endregion

        #region Constructor
        public EmployeeLeaveAllocationBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeLeaveRequestRepository employeeLeaveRequestRepository, IEmployeeLeaveAllocationRepository employeeLeaveAllocationRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _employeeLeaveRequestRepository = employeeLeaveRequestRepository;
            _employeeLeaveAllocationRepository = employeeLeaveAllocationRepository;
        }
        #endregion

        #region CustomMethods
        public Result<bool> ApprovedEmployeeLeaveRequest(int id)
        {
            if (id > 0)
            {
                try
                {
                    var data = _employeeLeaveRequestRepository.GetFirstOrDefault(u => u.Id == id);
                    if (data != null)
                    {
                        EmployeeLeaveAllocation employeeLeaveAllocation = new EmployeeLeaveAllocation();
                        employeeLeaveAllocation.DateCreated = DateTime.Now;
                        employeeLeaveAllocation.EmployeeId = data.RequestingEmployeeId;
                        employeeLeaveAllocation.EmployeeLeaveTypeId = data.EmployeeLeaveTypeId;
                        var day = (data.EndDate.Day - data.StartDate.Day);
                        employeeLeaveAllocation.NumberOfDays = day < 0 ? -day : day;
                        employeeLeaveAllocation.Period = 1;
                        _employeeLeaveAllocationRepository.Add(employeeLeaveAllocation);
                    }
                    data.Approved = (int)EnumEmployeeLeaveRequestStatus.Approved;
                    _employeeLeaveRequestRepository.Update(data);
                    _unitOfWork.Save();
                    return new Result<bool>(true, Constant.RecordCreateSuccessfully);
                }
                catch (System.Exception ex)
                {
                    return new Result<bool>(false, Constant.RecordUpdateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
            {
                return new Result<bool>(false, Constant.RecordCreateNotBeEmpty);
            }
        } 
        #endregion
    }
}
