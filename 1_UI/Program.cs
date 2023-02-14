using _2_Services;
using _2_Services.Interfaces;
using _2_Services.ServiceClasses;
using _3_Repository;
using _3_Repository.Interfaces;
using _3_Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _1_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(option => option.AddPolicy("corsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            builder.Services.AddControllers();

            // builder.Services.AddAutoMapper(typeof(Mapping));
            builder.Services.AddRepoDependencies();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IChildService, ChildService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Add services to the container.

            // Configure the HTTP request pipeline.
            app.UseCors("corsPolicy");

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