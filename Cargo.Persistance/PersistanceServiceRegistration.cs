using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Services.Repositories;
using CarGo.Persistance.Contexts;
using CarGo.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarGo.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("nArch_Cargo"));
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CarGo")));
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();

            return services;
        }
    }
}
