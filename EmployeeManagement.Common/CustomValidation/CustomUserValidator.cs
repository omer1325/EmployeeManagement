using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.CustomValidation
{
    public class CustomUserValidator : IUserValidator<Employee>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<Employee> manager, Employee user)
        {
            List<IdentityError> errors = new List<IdentityError>();

            string[] Digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (var item in Digits)
            {
                if (user.UserName[0].ToString() == item)
                {
                    errors.Add(new IdentityError() { Code = "UserNameContainsFirstLetterDigits", Description = ResultConstant.UserNameCanNotStartDigit });
                }
            }
            if (errors.Count == 0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
        }
    }
}
