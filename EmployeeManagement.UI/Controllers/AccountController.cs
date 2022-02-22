using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.SessionOperations;
using EmployeeManagement.Common.ViewModels;
using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, RoleManager<Employee> roleManager = null) : base(userManager, signInManager)
        {
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(EmployeeAccountLoginVM userLogin)
        {
            if (ModelState.IsValid)
            {
                Employee employee = await userManager.FindByEmailAsync(userLogin.Email);

                if (employee != null)
                {
                    bool userCheck = await userManager.CheckPasswordAsync(employee, userLogin.Password);

                    if (userCheck)
                    {
                        //If there is a cookie about the user, it deletes it, because the user logs in again.
                        await signInManager.SignOutAsync();

                        var result = await signInManager.PasswordSignInAsync(employee, userLogin.Password, userLogin.RememberMe, false);

                        //var loginEmplyee = _employeeRepository.GetFirstOrDefault(u => u.Email == userLogin.Email);

                        var loginEmployeeInfo = new SessionContext()
                        {
                            Email = employee.Email,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            LoginId = employee.Id,
                            Picture = employee.Picture,
                            IsAdmin = false
                        };

                        HttpContext.Session.SetString(Constant.LoginUserInfo, JsonConvert.SerializeObject(loginEmployeeInfo));

                        return RedirectToAction("Index", "EmployeeLeaveTypes");
                    }
                    else
                    {
                        ModelState.AddModelError("", Constant.EmailOrPassworndWrong);
                    }
                }
                else
                {
                    ModelState.AddModelError("", Constant.DoesNotHaveEmail);
                }

            }

            return View(userLogin);
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(EmployeeAccountSignUpVM userSignUp)
        {
            if (ModelState.IsValid)
            {
                if (userManager.Users.Any(u => u.PhoneNumber == userSignUp.PhoneNumber))
                {
                    ModelState.AddModelError("", Constant.PhoneNumberAlreadyExist);
                    return View(userSignUp);
                }
                Employee newEmployee = new Employee();
                newEmployee.UserName = userSignUp.UserName;
                newEmployee.Email = userSignUp.Email;
                newEmployee.PhoneNumber = userSignUp.PhoneNumber;

                IdentityResult result = await userManager.CreateAsync(newEmployee, userSignUp.Password);
                await userManager.AddToRoleAsync(newEmployee, Constant.Employee_Role);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    AddModelError(result);
                }
            }
            return View(userSignUp);
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(EmployeeAccountPasswordResetVM employeeAccountPasswordResetVM)
        {
            Employee employee = userManager.FindByEmailAsync(employeeAccountPasswordResetVM.Email).Result;
            if (employee != null)
            {
                string passwordResetToken = userManager.GeneratePasswordResetTokenAsync(employee).Result;

                string passwordResetLink = Url.Action("ResetPasswordConfirm", "Account", new
                {
                    userId = employee.Id,
                    token = passwordResetToken,
                }, HttpContext.Request.Scheme);

                Common.Helper.PasswordReset.PasswordResetSendEmail(passwordResetLink, employee.Email);
                ViewBag.status = "success";
            }
            else
            {
                ModelState.AddModelError("", Constant.DoesNotHaveEmail);
            }

            return View(employeeAccountPasswordResetVM);
        }

        public IActionResult ResetPasswordConfirm(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        //Bind ile PasswordResetViewModel sınıfından sadece belirttiğimiz property gelicek 
        [HttpPost]
        public async Task<IActionResult> ResetPasswordConfirm([Bind("PasswordNew")] EmployeeAccountPasswordResetVM employeeAccountPasswordResetVM )
        {
            string token = TempData["token"].ToString();
            string userId = TempData["userId"].ToString();

            Employee employee = await userManager.FindByIdAsync(userId);
            if (employee != null)
            {
                IdentityResult result = await userManager.ResetPasswordAsync(employee, token, employeeAccountPasswordResetVM.PasswordNew);

                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(employee);

                    ViewBag.status = "success";
                }
                else
                {
                    AddModelError(result);
                }
            }
            else
            {
                ModelState.AddModelError("", Constant.OccurredAnError);
            }
            return View(employeeAccountPasswordResetVM);
        }
    }
}
