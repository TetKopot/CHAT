using ChatApp.DataBase;
using ChatApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config) => _config = config;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<RoleManager<IdentityRole>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvcWithDefaultRoute();
            
        }
       
    }
}
