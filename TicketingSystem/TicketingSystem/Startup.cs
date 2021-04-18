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
using TicketingSystem.Repository;
using TicketingSystem.Repository.Interfaces;
using TicketingSystem.Services;
using TicketingSystem.Services.Interfaces;

namespace TicketingSystem
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
            services.AddDbContext<TicketingSystemDbContext>(
                x=> x.UseSqlServer(Configuration.GetConnectionString("TicketingSystem"))
                );

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                    options =>
                    {
                        options.ExpireTimeSpan = TimeSpan.FromDays(int.Parse(Configuration["CookieExpirationPeriod"]));
                        options.LoginPath = "/Auth/SignIn";
                        options.AccessDeniedPath = "/Auth/AccessDenied";
                    }
                );

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy =>
                {
                    policy.RequireClaim("IsAdmin", "True");
                });
            });

            services.AddControllersWithViews();

            // register services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITicketsService, TicketsService>();

            //register repositories
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<ITicketsRepository, TicketsRepository>();
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
                app.UseExceptionHandler("/Auth/AccessDenied");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ticket}/{action=Overview}/{id?}");
            });
        }
    }
}
