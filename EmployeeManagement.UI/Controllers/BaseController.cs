using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.UI.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<Employee> userManager { get; }
        protected SignInManager<Employee> signInManager { get; }
        protected RoleManager<Employee> roleManager { get; }

        protected Employee CurrentUser => userManager.FindByNameAsync(User.Identity.Name).Result;

        // Since we give null to the roleManager here, the Member controller does not throw an error either. Since we do not use it in a member controller, we set it to null by default.
        public BaseController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, RoleManager<Employee> roleManager = null)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public void AddModelError(IdentityResult result)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
    }
}
