
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Soka.Application.AppCode.Services;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soka.WebUI
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg =>
            {
                var policyRule = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                cfg.Filters.Add(new AuthorizeFilter(policyRule));
            });

            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });
            services.AddDbContext<SokaDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("sokaCString"));
            });

            services.AddIdentity<SokaUser, SokaRole>()
                .AddEntityFrameworkStores<SokaDbContext>();

            services.Configure<IdentityOptions>(cfg => {
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredLength = 3;
                cfg.Password.RequiredUniqueChars = 1; //aAa

                cfg.SignIn.RequireConfirmedPhoneNumber = false;
                cfg.SignIn.RequireConfirmedAccount = false;
                cfg.SignIn.RequireConfirmedEmail = true;

                cfg.Lockout.MaxFailedAccessAttempts = 3;

                cfg.User.RequireUniqueEmail = true;
                //cfg.User.AllowedUserNameCharacters = "";
            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.Cookie.Name = "soka";
                cfg.LoginPath = "/signin.html";
                cfg.LogoutPath = "/logout.html";

                cfg.AccessDeniedPath = "/accessdenied.html";

                cfg.ExpireTimeSpan = new TimeSpan(0, 1, 0);
                cfg.Cookie.HttpOnly = true;
            });

            services.AddScoped<UserManager<SokaUser>>();
            services.AddScoped<SignInManager<SokaUser>>();
            services.AddScoped<RoleManager<SokaRole>>();

            services.AddAuthentication();
            services.AddAuthorization();

            services.Configure<CryptoServiceOptions>(cfg =>
            {
                configuration.GetSection("cryptography").Bind(cfg);
            });
            services.AddSingleton<CryptoService>();
            services.Configure<EmailServiceOptions>(cfg =>
            {
                configuration.GetSection("emailAccount").Bind(cfg);
            });
            services.AddSingleton<EmailService>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith("Soka."))
                .ToArray();
            services.AddMediatR(assemblies);

            services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Singleton);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.SeedMembership();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(name: "defaultAdmin",
                   areaName: "Admin",
                   pattern: "admin/{controller=home}/{action=index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
