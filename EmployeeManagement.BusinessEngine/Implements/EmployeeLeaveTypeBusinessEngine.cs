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

        #endregion

        #region Constructor
        public EmployeeLeaveTypeBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region CustomMethods
        public Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes()
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.GetAll().ToList();

            var leaveTypes = _mapper.Map<List<EmployeeLeaveType>, List<EmployeeLeaveTypeVM>>(data);

            return new Result<List<EmployeeLeaveTypeVM>>(true, ResultConstant.RecordFound, leaveTypes);
        }

        public Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    leaveType.DateCreated = DateTime.Now;
                    _unitOfWork.employeeLeaveTypeRepository.Add(leaveType);
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

        public Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveType(int id)
        {
            var data = _unitOfWork.employeeLeaveTypeRepository.Get(id);
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
                    _unitOfWork.employeeLeaveTypeRepository.Update(leaveType);
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

        #endregion
    }
}
