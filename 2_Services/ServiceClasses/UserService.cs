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
            return mapper.Map<UserModel>(await rep.Add(mapper.Map<User>(
                new UserModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    HMO = user.HMO,
                    IDNumber = user.IDNumber,
                    Children = user.Children,
                })));
        }

        public async Task Delete(int id)
        {
             rep.Delete(id);
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return mapper.Map<List<UserModel>>(await rep.GetAll());
        }

        public async Task<UserModel> GetById(int id)
        {
            return await mapper.Map<Task<UserModel>>(rep.GetById(id));
        }

        public async Task Update(UserModel user)
        {
             rep.Update(mapper.Map<User>(user));
        }
    }
}
