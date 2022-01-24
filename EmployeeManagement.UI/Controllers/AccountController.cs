using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.ViewModels;
using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

                        return RedirectToAction("Index", "EmployeeLeaveTypes");
                    }
                    else
                    {
                        ModelState.AddModelError("", ResultConstant.EmailOrPassworndWrong);
                    }
                }
                else
                {
                    ModelState.AddModelError("", ResultConstant.DoesNotHaveEmail);
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
                Employee newEmployee = new Employee();
                newEmployee.UserName = userSignUp.UserName;
                newEmployee.Email = userSignUp.Email;

                IdentityResult result = await userManager.CreateAsync(newEmployee, userSignUp.Password);

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
    }
}
