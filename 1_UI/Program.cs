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

            builder.Services.AddCors(option => option.AddPolicy("corsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            builder.Services.AddControllers();

            builder.Services.AddRepoDependencies();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IChildService, ChildService>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
