
using CarGo.Application;
using CarGo.Persistance;
using Core.CrossCuttingConcerns.Exceptions.Extensions;

namespace CarGo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddHttpContextAccessor(); // DO NOT FORGET TO ADD, IT IS USED IN FILELOGGER!

            // add configurations for layers
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistanceServices(builder.Configuration);

            //builder.Services.AddDistributedMemoryCache();
            builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (app.Environment.IsProduction())
                app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
