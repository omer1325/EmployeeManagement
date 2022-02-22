using AutoMapper;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.BusinessEngine.ResultModels;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.SessionOperations;
using EmployeeManagement.Common.ViewModels;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.BusinessEngine.Implements
{
    public class EmployeeLeaveRequestBusinessEngine : IEmployeeLeaveRequestBusinessEngine
    {
        private readonly IEmployeeLeaveRequestRepository _employeeLeaveRequestRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeLeaveRequestBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeLeaveRequestRepository employeeLeaveRequestRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _employeeLeaveRequestRepository = employeeLeaveRequestRepository;
        }

        public Result<List<EmployeeLeaveRequestVM>> GetAllLeaveRequestByUserId(string emploeeId)
        {
            var data = _employeeLeaveRequestRepository.GetAll(
                u => u.RequestingEmployeeId == emploeeId 
                && u.Cancelled == false, 
                includeProperties: "RequestingEmployee,EmployeeLeaveType").ToList();

            var leaveRequests = _mapper.Map<List<EmployeeLeaveRequest>, List<EmployeeLeaveRequestVM>>(data);

            foreach (var item in leaveRequests)
            {
                item.LeaveTypeText = item.EmployeeLeaveType.Name;
                item.ApprovedStatus = (EnumEmployeeLeaveRequestStatus)item.Approved;              
            }

            return new Result<List<EmployeeLeaveRequestVM>>(true, Constant.RecordsFound, leaveRequests);
        }

        public Result<EmployeeLeaveRequestVM> CreateEmployeeLeaveRequest(EmployeeLeaveRequestVM employeeLeaveRequestVM, SessionContext employee)
        {
            if (employeeLeaveRequestVM != null)
            {
                try
                {
                    var leaveRequest = _mapper.Map<EmployeeLeaveRequestVM, EmployeeLeaveRequest>(employeeLeaveRequestVM);
                    leaveRequest.RequestingEmployeeId = employee.LoginId;
                    leaveRequest.Cancelled = false;
                    leaveRequest.DateRequest = DateTime.Now;
                    leaveRequest.Approved = (int)EnumEmployeeLeaveRequestStatus.Send_Approved;
                    _employeeLeaveRequestRepository.Add(leaveRequest);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveRequestVM>(true, Constant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<EmployeeLeaveRequestVM>(false, Constant.RecordCreateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
            {
                return new Result<EmployeeLeaveRequestVM>(false, Constant.RecordCreateNotBeEmpty);
            }
        }

        public Result<EmployeeLeaveRequestVM> EditEmployeeLeaveRequest(EmployeeLeaveRequestVM employeeLeaveRequestVM, SessionContext employee)
        {
            if (employeeLeaveRequestVM != null)
            {
                try
                {
                    var leaveRequest = _mapper.Map<EmployeeLeaveRequestVM, EmployeeLeaveRequest>(employeeLeaveRequestVM);
                    leaveRequest.Approved = (int)employeeLeaveRequestVM.ApprovedStatus;
                    leaveRequest.RequestingEmployeeId = employee.LoginId;
                    _employeeLeaveRequestRepository.Update(leaveRequest);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveRequestVM>(true, Constant.RecordUpdateSuccessfully);
                }
                catch (System.Exception ex)
                {
                    return new Result<EmployeeLeaveRequestVM>(false, Constant.RecordUpdateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
            {
                return new Result<EmployeeLeaveRequestVM>(false, Constant.RecordCreateNotBeEmpty);
            }
        }

        public Result<EmployeeLeaveRequestVM> GetAllLeaveRequestById(int id)
        {
            var data = _employeeLeaveRequestRepository.Get(id);
            if (data != null)
            {
                var leaveRequest = _mapper.Map<EmployeeLeaveRequest, EmployeeLeaveRequestVM>(data);
                leaveRequest.ApprovedStatus = (EnumEmployeeLeaveRequestStatus)data.Approved;
                leaveRequest.LeaveTypeText = data.EmployeeLeaveType.Name;
                return new Result<EmployeeLeaveRequestVM>(true, Constant.RecordFound, leaveRequest);
            }
            else
            {
                return new Result<EmployeeLeaveRequestVM>(true, Constant.RecordNotFound);
            }
        }

        public Result<EmployeeLeaveRequestVM> RemoveEmployeeLeaveRequest(int id)
        {
            var data = _employeeLeaveRequestRepository.Get(id);

            if (data != null)
            {
                data.Cancelled = true;
                _employeeLeaveRequestRepository.Update(data);
                _unitOfWork.Save();
                return new Result<EmployeeLeaveRequestVM>(true, Constant.RecordDeleteSuccessfully);
            }
            else
            {
                return new Result<EmployeeLeaveRequestVM>(false, Constant.RecordDeleteNotSuccessfully);
            }
        }

        public Result<List<EmployeeLeaveRequestVM>> GetSenApprovedLeaveRequests()
        {
            var data = _employeeLeaveRequestRepository.GetAll(
               u => u.Approved == (int)EnumEmployeeLeaveRequestStatus.Send_Approved
               && u.Cancelled == false,
               includeProperties: "RequestingEmployee,EmployeeLeaveType").ToList();

            var leaveRequests = _mapper.Map<List<EmployeeLeaveRequest>, List<EmployeeLeaveRequestVM>>(data);

            foreach (var item in leaveRequests)
            {
                item.LeaveTypeText = item.EmployeeLeaveType.Name;
                item.ApprovedStatus = (EnumEmployeeLeaveRequestStatus)item.Approved;
                item.RequestEmployeeName = item.RequestingEmployee.Email;
            }

            return new Result<List<EmployeeLeaveRequestVM>>(true, Constant.RecordsFound, leaveRequests);
        }

        public Result<bool> RejectEmployeeLeaveRequest(int id)
        {
            var data = _employeeLeaveRequestRepository.Get(id);
            if (data != null)
            {
                try
                {
                    data.Approved = (int)EnumEmployeeLeaveRequestStatus.Rejected;
                    _employeeLeaveRequestRepository.Update(data);
                    _unitOfWork.Save();
                    return new Result<bool>(true, Constant.RecordCreateSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<bool>(true, ex.Message.ToString());
                }
            }
            return new Result<bool>(true, Constant.RecordCreateNotSuccessfully);
        }
    }
}
