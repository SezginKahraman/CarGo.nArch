using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Pipelines.Transactions;
using Core.Application.Rules;
using FluentValidation;
using Core.Application.Pipelines.Validations;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Serilog;
using Core.CrossCuttingConcerns.Serilog.Loggers;

namespace CarGo.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // adds all businessRules to the IoC
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            // Fluent validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // MediatR
            services.AddMediatR(conf =>
            {
                // add mediatR
                conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                // pipelines - > Check all request by its fluent validation rules automaticaly
                conf.AddOpenBehavior(typeof(RequestValidatorBehavior<,>));

                // add transaction implementation
                conf.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));

                // add caching implementation
                conf.AddOpenBehavior(typeof(CachingBehavior<,>));

                // add removing cache implementation
                conf.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));

                // add removing cache implementation
                conf.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddSingleton<LoggerServiceBase, FileLogger>();

            return services;
        }

        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddScoped(item);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }

            return services;
        }
    }
}
