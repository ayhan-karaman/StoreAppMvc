using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Extensions
{
    public static class SeviceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
             services.AddDbContext<RepositoryContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"), b => b.MigrationsAssembly("StoreApp"));
                options.EnableSensitiveDataLogging(true);
             });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options => 
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.Cookie.Name = "StroreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));

        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICateogoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IAuthService, AuthManager>();
        }

        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(opt => {
                opt.LowercaseUrls = true;
                opt.AppendTrailingSlash = false;
            });
        }
    
        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            // services.ConfigureApplicationCookie(opt => {
            //     opt.LoginPath = new PathString("/Account/Login");
            //     opt.ReturnUrlParameter =  CookieAuthenticationDefaults.ReturnUrlParameter;
            //     opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            //     opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
            // });
        }
    }
}