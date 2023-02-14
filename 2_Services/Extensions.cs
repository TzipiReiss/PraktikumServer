using _2_Services.Interfaces;
using _2_Services.Models;
using _2_Services.ServiceClasses;
using _3_Repository;
using _3_Repository.Entities;
using _3_Repository.Interfaces;
using _3_Repository.Repositories;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace _2_Services
{
    public static class Extensions
    {
        public static IServiceCollection AddRepoDependencies(this IServiceCollection service)
        {
            MapperConfiguration config = new MapperConfiguration(
                conf =>
                {
                    conf.CreateMap<User, UserModel>().ReverseMap();
                    conf.CreateMap<Child, ChildModel>().ReverseMap();
                });
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IChildRepository, ChildRepository>();

            IMapper mapper = config.CreateMapper();
            service.AddSingleton(mapper);

            service.AddDbContext<IDataSource, Context>();
            return service;
        }
    }
}
