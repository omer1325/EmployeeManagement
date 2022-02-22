using AutoMapper;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.ViewModels;
using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers
{
    public class EmployeeAccountController : BaseController
    {
        private readonly IMapper _mapper;

        public EmployeeAccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, RoleManager<Employee> roleManager = null, IMapper mapper = null) : base(userManager, signInManager, roleManager)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            Employee employee = CurrentUser;

            EmployeeVM employeeVM = _mapper.Map<Employee, EmployeeVM>(employee);
            return View(employeeVM);
        }

        public IActionResult EmployeeEdit()
        {
            Employee employee = CurrentUser;
            EmployeeVM employeeVM = _mapper.Map<Employee, EmployeeVM>(employee);

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(EnumEmployeeGender)));

            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeEdit(EmployeeVM employeeVM, IFormFile employeePicture)
        {
            ModelState.Remove("Password");
            ModelState.Remove("UserName");
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(EnumEmployeeGender)));
            if (ModelState.IsValid)
            {
                Employee employee = CurrentUser;

                string phone = userManager.GetPhoneNumberAsync(employee).Result;
                if (phone != employeeVM.PhoneNumber)
                {
                    if (userManager.Users.Any(u => u.PhoneNumber == employeeVM.PhoneNumber))
                    {
                        ModelState.AddModelError("", Constant.PhoneNumberAlreadyExist);
                        return View(employeeVM);
                    }
                }
                if (employeePicture != null && employeePicture.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(employeePicture.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/EmploeePicture", fileName);
                    using ( var stream = new FileStream(path, FileMode.Create))
                    {
                        await employeePicture.CopyToAsync(stream);
                        employee.Picture = "/images/EmploeePicture/" + fileName;
                    }
                }
                employee.Email = employeeVM.Email;
                employee.PhoneNumber = employeeVM.PhoneNumber;
                employee.City = employeeVM.City;
                employee.BirthDay = employeeVM.BirthDay;
                employee.Gender = (int)employeeVM.Gender;
                employee.FirstName = employeeVM.FirstName;
                employee.LastName = employeeVM.LastName;

                IdentityResult result = await userManager.UpdateAsync(employee);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(employee);
                    await signInManager.SignOutAsync();
                    await signInManager.SignInAsync(employee, true);
                }
                else
                {
                    AddModelError(result);
                }
            }                      
            return View(employeeVM);
        }

        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasswordChange(EmployeeAccountPasswordChangeVM employeeAccountPasswordChangeVM)
        {
            if (ModelState.IsValid)
            {
                Employee employee = CurrentUser;
                bool exist = userManager.CheckPasswordAsync(employee, employeeAccountPasswordChangeVM.PasswordOld).Result;
                if (exist)
                {
                    IdentityResult result = userManager.ChangePasswordAsync(employee, employeeAccountPasswordChangeVM.PasswordOld, employeeAccountPasswordChangeVM.PasswordNew).Result;
                    if (result.Succeeded)
                    {
                        userManager.UpdateSecurityStampAsync(employee);
                        signInManager.SignOutAsync();
                        signInManager.PasswordSignInAsync(employee, employeeAccountPasswordChangeVM.PasswordNew, true, false);
                        ViewBag.success = "true";
                    }
                    else
                    {
                        AddModelError(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", Constant.OldPasswordWrong);
                }
            }
            return View(employeeAccountPasswordChangeVM);
        }



        public void LogOut()
        {
            signInManager.SignOutAsync();
        }
    }
}
