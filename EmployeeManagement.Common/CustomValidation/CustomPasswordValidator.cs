using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.CustomValidation
{
    public class CustomPasswordValidator : IPasswordValidator<Employee>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<Employee> manager, Employee user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                if (!user.Email.Contains(user.UserName))
                {
                    errors.Add(new IdentityError() { Code = "PasswordCotainsUserName", Description = ResultConstant.PasswordNotContainUserName });
                }
            }
            if (password.ToLower().Contains("1234"))
            {
                errors.Add(new IdentityError() { Code = "PaswordContains1234", Description = ResultConstant.PasswordNotContain1234 });
            }
            if (password.ToLower().Contains(user.Email.ToLower()))
            {
                errors.Add(new IdentityError() { Code = "PasswordContainsEmail", Description = ResultConstant.PasswordNotContainEmail });
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
