using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.BusinessEngine.Implements;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.CustomValidation;
using EmployeeManagement.Common.Mappings;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;
using EmployeeManagement.Data.Implementaion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<EmployeeManagementContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("IdentityConnection"));
            });

            services.AddAutoMapper(typeof(Maps));

            //services.AddScoped<IEmployeeLeaveAllocationRepository, EmployeeLeaveAllocationRepository>();
            services.AddScoped<IEmployeeLeaveRequestRepository, EmployeeLeaveRequestRepository>();
            services.AddScoped<IEmployeeLeaveTypeRepository, EmployeeLeaveTypeRepository>();
            services.AddScoped<IEmployeeLeaveAllocationRepository, EmployeeLeaveAllocationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmployeeLeaveTypeBusinessEngine, EmployeeLeaveTypeBusinessEngine>();
            services.AddScoped<IEmployeeLeaveRequestBusinessEngine, EmployeeLeaveRequestBusinessEngine>();
            services.AddScoped<IEmployeeLeaveAllocationBusinessEngine, EmployeeLeaveAllocationBusinessEngine>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.Name = "MainSession";
            });

            services.AddIdentity<Employee, IdentityRole>( opts => 
            {
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abc?defg?h?ijklmno?pqrs?tu?vwxyzABC?DEFG?HI?JKLMNO?PQRS?TU?VWXYZ0123456789-._";
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireDigit = true;
            })
                .AddEntityFrameworkStores<EmployeeManagementContext>()
                .AddPasswordValidator<CustomPasswordValidator>()
                .AddUserValidator<CustomUserValidator>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddDefaultTokenProviders();

            //CookieBuilder cookieBuilder = new CookieBuilder();

            //cookieBuilder.Name = "EmployeeManagement";
            //cookieBuilder.HttpOnly = false;
            //cookieBuilder.SameSite = SameSiteMode.Lax;
            //cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            SeedData.Seed(userManager, roleManager);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=LogIn}/{id?}"
                    );
                endpoints.MapRazorPages();
            });
        }
    }
}
