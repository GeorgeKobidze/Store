//using Domain.Infrastructure.AutoMapperProfile;
//using Domain.Infrastructure.Services;
//using Domain.Infrastructure.Services.UnitOfWork;
//using Domain.Infrastructure.Services.UserService;
//using MediatR;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.InjectedServices
{
    public static class InjectedServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration )
        {
            //services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

           // services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
           // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
           //
           // services.AddScoped<IUserService,UserService>();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(option =>
            //{
            //    option.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
            //        .GetBytes(configuration.GetSection("AppSettings:Token").Value)),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});

            //services.AddAutoMapper(typeof(AutoMappersProfile));
            //
            //services.AddMediatR(typeof(InjectedServices));
            return services;
        }

    }
}
