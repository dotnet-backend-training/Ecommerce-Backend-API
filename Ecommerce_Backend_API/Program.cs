
using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Infrastructure.Data;
using Ecommerce_Backend_Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using System.Reflection;

namespace Ecommerce_Backend_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // AppDbContext service
            string connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection") ?? 
                throw new InvalidOperationException
                (
                    "Connection string was not found in the application configuration."
                );

            builder.Services.AddDbContext<AppDbContext>((options)=> {
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
            });

            // FluentValidation service
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // IAuthRepository service
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();

            // Identity service 
            builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric= true;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
