using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity;


namespace EmployeeManagement.Common.ConstantModels
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<Employee> userManager)
        {
            if (userManager.FindByNameAsync(Constant.Admin_Email).Result == null)
            {
                var user = new Employee
                {
                    UserName = Constant.Admin_Name,
                    Email = Constant.Admin_Email
                };

                var result = userManager.CreateAsync(user, Constant.Admin_Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Constant.Admin_Role);
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(Constant.Admin_Role).Result)
            {
                var role = new IdentityRole
                {
                    Name = Constant.Admin_Role
                };
                var result = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync(Constant.Employee_Role).Result)
            {
                var role = new IdentityRole
                {
                    Name = Constant.Employee_Role
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
