﻿using Domain.Application.Customers;
using Domain.Application.Services.Categories;
using Domain.Application.Services.CustomerAddresses;
using Domain.Application.Services.ProductCategories;
using Domain.Application.Services.ProductFiles;
using Domain.Application.Services.Products;
using Domain.Application.Services.UserRoles;
using Domain.Application.Services.Users;
using Domain.Infrastructure.AutoMapperProfile;
using Domain.Infrastructure.Services;
using Domain.Infrastructure.Services.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Domain.Application.InjectedServices
{
    public static class InjectedServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerAddressService, CustomerAddressService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IProductCategoryService,ProductCategoryService>();
            services.AddScoped<IProductFileService,ProductFileService>();



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                    .GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAutoMapper(typeof(AutoMappersProfile));
            //
            //services.AddMediatR(typeof(InjectedServices));
            return services;
        }

    }
}
