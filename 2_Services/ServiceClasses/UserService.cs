using _2_Services.Interfaces;
using _2_Services.Models;
using _3_Repository.Entities;
using _3_Repository.Interfaces;
using _3_Repository.Repositories;
using AutoMapper;

namespace _2_Services.ServiceClasses
{
    public class UserService : IUserService
    {
        private readonly IUserRepository rep;
        private readonly IMapper mapper;
        public UserService(IUserRepository rep, IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }

        public async Task<UserModel> Add(UserModel user)
        {
            return mapper.Map<UserModel>(await rep.Add(mapper.Map<User>(user)));
        }

        public async Task Delete(int id)
        {
            await rep.Delete(id);
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return mapper.Map<List<UserModel>>(await rep.GetAll());
        }

        public async Task<UserModel> GetById(int id)
        {
            return mapper.Map<UserModel>(await rep.GetById(id));
        }

        public async Task Update(UserModel user)
        {
            await rep.Update(mapper.Map<User>(user));
        }
    }
}
