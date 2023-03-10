
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Soka.Application.AppCode.Extensions;
using Soka.Application.AppCode.Services;
using Soka.Domain.AppCode.Providers;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities.Membership;
using System;
using System.Linq;

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
            services.AddControllersWithViews();

            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });
            services.AddDbContext<SokaDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("sokaCString"));
            });

            services.AddIdentity<SokaUser, SokaRole>()
                .AddEntityFrameworkStores<SokaDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<SokaIdentityErrorDescriber>();

            services.AddScoped<UserManager<SokaUser>>();
            services.AddScoped<SignInManager<SokaUser>>();
            services.AddScoped<RoleManager<SokaRole>>();

            services.Configure<AntiforgeryOptions>(cfg =>
            {
                cfg.Cookie.Name = "soka-ant";
            });


            services.Configure<CryptoServiceOptions>(cfg =>
            {
                configuration.GetSection("cryptography").Bind(cfg);
            });
            services.AddSingleton<ICryptoService, CryptoService>();
            services.Configure<EmailServiceOptions>(cfg =>
            {
                configuration.GetSection("emailAccount").Bind(cfg);
            });
            services.AddSingleton<IEmailService, EmailService>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IClaimsTransformation, AppClaimProvider>();
            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith("Soka."))
                .ToArray();
            services.AddMediatR(assemblies);
            services.AddAutoMapper(assemblies);

            services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Singleton);
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(cfg =>
                {
                    cfg.Cookie.Name = "soka";
                    cfg.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    cfg.LoginPath = "/signin.html";
                    cfg.AccessDeniedPath = "/accessdenied.html";
                });

            services.AddAuthorization(cfg =>
            {

                foreach (string principal in AppClaimProvider.principals)
                {
                    cfg.AddPolicy(principal, p =>
                    {
                        p.RequireAssertion(handler =>
                        {
                            return handler.User.HasAccess(principal);

                        });
                    });
                }
            });
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

