using AutoMapper;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.BusinessEngine.ResultModels;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.ViewModels;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.BusinessEngine.Implements
{
    public class EmployeeLeaveTypeBusinessEngine : IEmployeeLeaveTypeBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmployeeLeaveTypeRepository _employeeLeaveTypeRepository;

        #endregion

        #region Constructor
        public EmployeeLeaveTypeBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeLeaveTypeRepository employeeLeaveTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _employeeLeaveTypeRepository = employeeLeaveTypeRepository;
        }
        #endregion

        #region CustomMethods
        public Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes()
        {
            var data = _employeeLeaveTypeRepository.GetAll(filter => filter.IsActive == true).ToList();

            var leaveTypes = _mapper.Map<List<EmployeeLeaveType>, List<EmployeeLeaveTypeVM>>(data);

            return new Result<List<EmployeeLeaveTypeVM>>(true, ResultConstant.RecordsFound, leaveTypes);
        }

        public Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    leaveType.DateCreated = DateTime.Now;
                    leaveType.IsActive = true;

                    _employeeLeaveTypeRepository.Add(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreateSuccessfully);
                }
                catch (System.Exception ex)
                {
                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotBeEmpty);
            }
        }

        public Result<EmployeeLeaveTypeVM> GetEmployeeLeaveTypeById(int id)
        {
            var data = _employeeLeaveTypeRepository.Get(id);
            if (data != null)
            {
                var leaveType = _mapper.Map<EmployeeLeaveType, EmployeeLeaveTypeVM>(data);

                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordFound, leaveType);
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordNotFound);
            }
        }

        public Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    _employeeLeaveTypeRepository.Update(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordUpdateSuccessfully);
                }
                catch (System.Exception ex)
                {
                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordUpdateNotSuccessfully + "=>" + ex.Message.ToString());
                }
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotBeEmpty);
            }
        }

        public Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id)
        {
            var data = _employeeLeaveTypeRepository.Get(id);

            if (data != null)
            {
                data.IsActive = false;
                _employeeLeaveTypeRepository.Update(data);
                _unitOfWork.Save();
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordDeleteSuccessfully);
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordDeleteNotSuccessfully);
            }
        }

        #endregion
    }
}
