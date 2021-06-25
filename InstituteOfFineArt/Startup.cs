using InstituteOfFineArt.Areas.Admin.Services;
using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using InstituteOfFineArt.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

            services.AddScoped<AccountService, AccountServiceImpl>();
            services.AddScoped<RoleService, RoleServiceImpl>();
            services.AddScoped<LoginService, LoginServiceImpl>();
            services.AddScoped<ProfileService, ProfileServiceImpl>();
            services.AddScoped<CreateService, CreateServiceImpl>();
            services.AddScoped<ProfileSchoolService, ProfileSchoolServiceImpl>();
            services.AddScoped<IndexService, IndexServiceImpl>();
            services.AddScoped<SchoolService, SchoolServiceImpl>();
            services.AddScoped<TestcoreService, TestcoreServiceImpl>();
            services.AddScoped<ApprovalService, ApprovalServiceImpl>();
            services.AddScoped<EventService, EventServiceImpl>();
            services.AddScoped<DetailComService, DetailComServiceImpl>();
            services.AddSession();

            services.AddMvc();
            services.AddAuthentication
            (CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Index}/{action=Index}/{id?}");
            });
        }
    }
}
